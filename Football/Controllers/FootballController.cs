namespace Football.Controllers
{
    using Football.Data;
    using Microsoft.AspNet.Identity;
    using Models.Footballs;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    public class FootballController : Controller
    {
        public ActionResult All(int page = 1)
        {
            var db = new FootballDbContext();

            var pageSize = 5;

            var tactics = db.Footballs
                .OrderByDescending(t => t.Id)
                .Skip((page - 1) * pageSize)
                .Select(t => new ListTactics
                {
                    Id = t.Id,
                    Formation = t.Formation,
                    Image = t.Image,
                    TacticName = t.TacticName
                })               
                .ToList();

            ViewBag.CurrentPage = page;

            return View(tactics);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(CreateTactics model)
        {
            if (this.ModelState.IsValid)
            {
                var authorId = this.User.Identity.GetUserId();

                var tactic = new Football
                {
                    TacticName = model.TacticName,
                    Description = model.Description,
                    Formation = model.Formation,
                    PlayerPosition = model.PlayerPosition,
                    Image = model.Image,
                    AuthorId = authorId
                    
                };

                var db = new FootballDbContext();

                db.Footballs.Add(tactic);
                db.SaveChanges();

                return RedirectToAction("Details", new { id = tactic.Id });          
             }

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var db = new FootballDbContext();

            var tactic = db.Footballs
                .Include(t => t.Author)
                .Where(t => t.Id == id)
                .Select(t => new TacticsDetails
                {
                    TacticName = t.TacticName,
                    Formation = t.Formation,
                    Description = t.Description,
                    Image = t.Image,
                    PlayerPosition = t.PlayerPosition,
                    FullName = t.Author.FullName,
                    Id = t.Id
                })
                .FirstOrDefault();

            if (tactic == null)
            {
                return HttpNotFound();
            }

            return View(tactic);     
        }

        [Authorize]
        [HttpGet]
        public ActionResult Delete (int id)
        {
            var db = new FootballDbContext();

            var tactics = db.Footballs
                .Where(t => t.Id == id)
                .Select(t => new Delete
                {
                    TacticName = t.TacticName,
                    Formation = t.Formation,
                    Description = t.Description,
                    Image = t.Image,
                    PlayerPosition = t.PlayerPosition,
                    Id = t.Id          
                })
                .FirstOrDefault();

            if (tactics == null)
            {
                return HttpNotFound();
            }

            return View(tactics);
        }

        [Authorize]
        [ActionName("Delete")]
        [HttpPost]
        public ActionResult ConfirmDelete(int id)
        {
            var db = new FootballDbContext();

            var tactics = db.Footballs
                .Where(t => t.Id == id)
                .FirstOrDefault();

            if (tactics == null)
            {
                return HttpNotFound();
            }

            db.Footballs.Remove(tactics);
            db.SaveChanges();

            return RedirectToAction("All", "Football");
        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit (int id)
        {
            var db = new FootballDbContext();

            var tactics = db.Footballs
                .Where(t => t.Id == id)
                .Select(t => new Edit
                {
                    TacticName = t.TacticName,
                    Formation = t.Formation,
                    Description = t.Description,
                    Image = t.Image,
                    PlayerPosition = t.PlayerPosition,
                    Id = t.Id
                })
                .FirstOrDefault();
            if (tactics == null)
            {
                return HttpNotFound();
            }

            return View(tactics);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(CreateTactics models)
        {
            if (ModelState.IsValid)
            {
                using (var db = new FootballDbContext())
                {
                    var tactics = db.Footballs.Find(models.Id);

                    tactics.Description = models.Description;
                    tactics.Formation = models.Formation;
                    tactics.PlayerPosition = models.PlayerPosition;
                    tactics.TacticName = models.TacticName;
                    tactics.Image = models.Image;

                    db.SaveChanges();

                }
                return RedirectToAction("TacticsDetails", new { id = models.Id});
            }

            return View(models);
        }
    }
}