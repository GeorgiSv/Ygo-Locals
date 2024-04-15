namespace YgoLocals.Core.EntityServices.Match
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using YgoLocals.Data.Entities;
    using YgoLocals.Data;
    using Microsoft.EntityFrameworkCore;

    public class MatchService : IMatchService
    {
        private readonly ApplicationDbContext _dbContext;

        public MatchService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> StartAsync(string playerOneId, string playerTwoId, int? tournamentId = null)
        {
            var match = new Match()
            {
                PlayerOneId = playerOneId,
                PlayerTwoId = playerTwoId,
                TournamentId = tournamentId,
            };

            _dbContext.Match.Add(match);
            await _dbContext.SaveChangesAsync();

            return match.Id;
        }

        public async Task<string> EndAsync(string matchId, string winnerId)
        {
            var match = await GetByIdAsync(matchId);
            if (match is null)
            {
                throw new Exception("Match was not found in the database!");
            }

            match.WinnerId = winnerId;

            return match.Id;
        }

        public async Task<IList<Match>> GetAllByUser(string userId)
            => await _dbContext.Match
            .Where(m => m.PlayerOneId == userId || m.PlayerTwoId == userId)
            .AsNoTracking()
            .ToListAsync();

        public async Task<Match> GetByIdAsync(string id)
            => await _dbContext.Match.FirstOrDefaultAsync(m => m.Id == id);

        public async Task<bool> DeleteAsync(string id)
        {
            var match = await GetByIdAsync(id);

            if (match is null)
            {
                return false;
            }

            _dbContext.Match.Remove(match);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
