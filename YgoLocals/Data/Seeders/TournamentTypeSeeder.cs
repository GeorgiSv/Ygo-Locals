namespace YgoLocals.Data.Seeders
{
    using System;
    using System.Threading.Tasks;
    using YgoLocals.Data.Entities;
    using YgoLocals.Data.Entities.Enums;

    public class TournamentTypeSeeder : ISeeder
    {
        public Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.TournamentType.Any())
            {
                return Task.CompletedTask;
            }

            var tournamentTypeListToSeed = new List<TournamentType>();

            var classicTournamentType = new TournamentType()
            {
                 //Id = (int)TournamentTypeEnum.Classic,
                 Title = "Classic",
                 Description = "A classic local."
            };
            tournamentTypeListToSeed.Add(classicTournamentType);

            var twoDecksModeTournamentType = new TournamentType()
            {
                //Id = (int)TournamentTypeEnum.TwoDecksMode,
                Title = "Two Decks Mode",
                Description = "A local with two decks by every player."
            };
            tournamentTypeListToSeed.Add(twoDecksModeTournamentType);

            var survivalTournamentType = new TournamentType()
            {
                //Id = (int)TournamentTypeEnum.Survival,
                Title = "Survival",
                Description = "Survival mode with one deck."
            };
            tournamentTypeListToSeed.Add(survivalTournamentType);


            foreach (var toutnamentType in tournamentTypeListToSeed)
            {
                dbContext.TournamentType.Add(toutnamentType);
            }

            return Task.CompletedTask;
        }
    }
}
