namespace YgoLocals.Core.EntityServices.Match
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using YgoLocals.Data.Entities;
    using YgoLocals.Data;
    using Microsoft.EntityFrameworkCore;
    using YgoLocals.Infrastructure.Automapper;
    using YgoLocals.Models.Match;

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
            var match = await _dbContext.Match
            .FirstOrDefaultAsync(m => m.Id == matchId);

            if (match is null)
            {
                throw new Exception("Match was not found in the database!");
            }

            match.WinnerId = winnerId;
            await _dbContext.SaveChangesAsync();

            return match.Id;
        }

        public async Task<IList<MatchViewModel>> GetAllActiveByUser(string userId)
            => await _dbContext.Match
            .AsNoTracking()
            .Where(m => (m.PlayerOneId == userId || m.PlayerTwoId == userId) && m.WinnerId == null)
            .To<MatchViewModel>()
            .ToListAsync();

        public async Task<MatchViewModel> GetByIdAsync(string id)
            => await _dbContext.Match
            .To<MatchViewModel>()
            .FirstOrDefaultAsync(m => m.Id == id);

        public async Task<bool> DeleteAsync(string id)
        {
            var match = await _dbContext.Match.FirstOrDefaultAsync(m => m.Id == id);

            if (match is null)
            {
                return false;
            }

            _dbContext.Match.Remove(match);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<string> CreateAsync(string organizer)
        {
            var match = new Match()
            {
                PlayerOneId = organizer,
            };

            await _dbContext.Match.AddAsync(match);
            await _dbContext.SaveChangesAsync();

            return match.Id;
        }

        public async Task JoinAsync(string matchId, string playerTwo)
        {
            var match = await _dbContext.Match.FirstOrDefaultAsync(m => m.Id == matchId);

            if (match is null)
            {
                throw new Exception("Match could not be found!");
            }

            if (match.PlayerOneId == playerTwo)
            {
                throw new Exception("Cannot join in yor own match.");
            }

            match.PlayerTwoId = playerTwo;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IList<MatchViewModel>> GetAllAvaiable()
          => await _dbContext.Match
            .Where(m => m.PlayerTwoId == null)
            .AsNoTracking()
            .To<MatchViewModel>()
            .ToListAsync();

        public async Task<IList<MatchViewModel>> GetAllPastByUser(string userId)
          => await _dbContext.Match
            .AsNoTracking()
            .Where(m => (m.PlayerOneId == userId || m.PlayerTwoId == userId) && m.WinnerId != null)
            .To<MatchViewModel>()
            .ToListAsync();

    }
}
