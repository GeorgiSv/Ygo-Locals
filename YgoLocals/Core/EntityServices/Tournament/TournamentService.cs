namespace YgoLocals.Core.EntityServices.Tournament
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using YgoLocals.Data.Entities;
    using YgoLocals.Data;
    using Microsoft.EntityFrameworkCore;
    using YgoLocals.Models.Tournament;
    using YgoLocals.Infrastructure.Automapper;

    public class TournamentService : ITournamentService
    {
        private readonly ApplicationDbContext _dbContext;

        public TournamentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddPlayerAsync(int tournamentId, string playerId)
        {
            var tournament = await _dbContext.Tournament
                .Where(t => t.Id == tournamentId)
                .FirstOrDefaultAsync();

            if (tournament is null)
            {
                throw new Exception("Tournament does not exist!");
            }

            if (tournament.HasStarted == true)
            {
                throw new Exception("Tournament has already started yet!");
            }

            if (tournament.MaxPlayers >= tournament.Players.Count)
            {
                throw new Exception("No more space for players!");
            }

            var tournamentPlayer = new TournamentPlayer()
            {
                TournamentId = tournamentId,
                PlayerId = playerId,
            };

            _dbContext.TournamentPlayer.Add(tournamentPlayer);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<int> CreateAsync(string organizerId, int maxPeopleCount, int tournamentTypeId)
        {
            var tournament = new Tournament()
            {
                OrganizerId = organizerId,
                MaxPlayers = maxPeopleCount,
                TournamentTypeId = tournamentTypeId,
            };

            _dbContext.Tournament.Add(tournament);
            await _dbContext.SaveChangesAsync();

            return tournament.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tournament = await _dbContext.Tournament
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();

            if (tournament is null)
            {
                throw new Exception("Tournament not found.");
            }

            _dbContext.Tournament.Remove(tournament);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IList<BaseTournamentViewModel>> GetAllByUserAsync(string userId)
            => await _dbContext.Tournament
            .AsNoTracking()
            .Where(t => t.OrganizerId == userId)
            .To<BaseTournamentViewModel>()
            .ToListAsync();

        public async Task<IList<BaseTournamentViewModel>> GetAllAvaiableToJoinAsync()
         => await _dbContext.Tournament
            .AsNoTracking()
            .Where(t => t.HasStarted == false && t.Players.Count < t.MaxPlayers)
            .To<BaseTournamentViewModel>()
            .ToListAsync();

        public async Task<BaseTournamentViewModel> GetByIdAsync(int id)
            => await _dbContext.Tournament
            .AsNoTracking()
            .To<BaseTournamentViewModel>()
            .FirstOrDefaultAsync(t => t.Id == id);

        public async Task<int> StartAsync(int tournamentId, string userId)
        {
            var tournament = await GetByIdAndUSer(tournamentId, userId).FirstOrDefaultAsync();

            if (tournament is null)
            {
                throw new Exception("Tournament does not exist!");
            }

            tournament.HasStarted = true;
            await _dbContext.SaveChangesAsync();

            return tournament.Id;
        }

        private IQueryable<Tournament> GetByIdAndUSer(int tournamentId, string userId)
            => _dbContext.Tournament
            .Where(t => t.OrganizerId == userId && t.Id == tournamentId);
    }
}
