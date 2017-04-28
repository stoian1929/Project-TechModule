namespace Football.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Football.Data.FootballDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(Football.Data.FootballDbContext context)
        {
            if (context.Footballs.Any())
            {
                return;
            }

            var user = context.Users.FirstOrDefault();

            if (user == null)
            {
                return;
            }

            context.Footballs.Add(new Data.Football
            {
                TacticName = "Atack",
                Description = "Agains week oponent",
                Formation = "3-4-1-2",
                PlayerPosition =Data.PlayerPosition.FC,
                Image = "https://football-40ba.kxcdn.com/images/image/central-midfielder.jpg",
                AuthorId = user.Id
            });

            context.Footballs.Add(new Data.Football
            {
                TacticName = "Mid",
                Description = "Middle",
                Formation = "4-5-1",
                PlayerPosition = Data.PlayerPosition.AMC,
                Image = "https://football-40ba.kxcdn.com/images/image/central-midfielder.jpg",
                AuthorId = user.Id
            });

            context.Footballs.Add(new Data.Football
            {
                TacticName = "Def",
                Description = "Agains strong oponent",
                Formation = "5-4-1",
                PlayerPosition = Data.PlayerPosition.CB,
                Image = "https://football-40ba.kxcdn.com/images/image/central-midfielder.jpg",
                AuthorId = user.Id
            });
        }
    }
}
