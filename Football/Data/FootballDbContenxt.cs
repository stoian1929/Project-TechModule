namespace Football.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class FootballDbContext : IdentityDbContext<User>
    {
        public FootballDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Football> Footballs { get; set; }

        public static FootballDbContext Create()
        {
            return new FootballDbContext();
        }
    }
}