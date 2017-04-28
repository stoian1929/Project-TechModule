using Football.Data;
using Football.Models.Footballs;
using System.Linq;
using System.Web.Mvc;

namespace Football.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new FootballDbContext();

            var footballs = db.Footballs
                .OrderByDescending(f => f.Id)
                .Take(2)
                .Select(f => new ListTactics
                {
                    Id = f.Id,
                    TacticName = f.TacticName,
                    Formation = f.Formation,
                    Image = f.Image
                })
                .ToList();
           
            return View(footballs);
        }

       
    }
}