namespace YgoLocals.Core.EntityServices.TournamentType
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using YgoLocals.Data;
    using YgoLocals.Data.Entities;

    public class TournamentTypeService : ITournamentTypeService
    {
        private readonly ApplicationDbContext _dbContext;

        public TournamentTypeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAsync(string title, string description)
        {
            var tournamentType = new TournamentType()
            {
                Title = title,
                Description = description
            };

            _dbContext.TournamentType.Add(tournamentType);
            await _dbContext.SaveChangesAsync();

            return tournamentType.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tournamentType = await GetByIdAsync(id);

            if (tournamentType is null)
            {
                return false;
            }

            _dbContext.TournamentType.Remove(tournamentType);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditAsync(int id, string title, string description)
        {
            var tournamentType = await GetByIdAsync(id);

            if (tournamentType is null)
            {
                return false;
            }

            tournamentType.Title = title;
            tournamentType.Description = description;

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<TournamentType> GetByIdAsync(int id)
            => await _dbContext.TournamentType.FirstOrDefaultAsync(tt => tt.Id == id);
    }
}
