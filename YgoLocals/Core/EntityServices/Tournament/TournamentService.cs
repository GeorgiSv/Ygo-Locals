namespace YgoLocals.Core.EntityServices.Tournament
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using YgoLocals.Data.Entities;
    using YgoLocals.Data;
    using Microsoft.EntityFrameworkCore;
    using YgoLocals.Models.Tournament;
    using YgoLocals.Infrastructure.Automapper;
    using YgoLocals.Core.EntityServices.Deck;
    using YgoLocals.Models.TournamentPlayer;

    public class TournamentService : ITournamentService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IDeckService _deckService;

        public TournamentService(ApplicationDbContext dbContext, IDeckService deckService)
        {
            _dbContext = dbContext;
            _deckService = deckService;
        }

        public async Task<bool> JoinPlayerAsync(int tournamentId, string playerId, IList<string> deckIds)
        {
            var tournament = await _dbContext.Tournament
                .Where(t => t.Id == tournamentId)
                .Include(t => t.Players)
                .FirstOrDefaultAsync();

            if (tournament is null)
            {
                throw new Exception("Tournament does not exist!");
            }

            if (tournament.HasStarted == true)
            {
                throw new Exception("Tournament has already started yet!");
            }

            if (tournament.MaxPlayers <= tournament.Players.Count)
            {
                throw new Exception("No more space for players!");
            }

            if (!await _deckService.AreValidDecksPerUser(deckIds, playerId))
            {
                Console.WriteLine("Deck/s does not exist in user.");
                return false;
            }

            var tournamentPlayer = new TournamentPlayer()
            {
                TournamentId = tournamentId,
                PlayerId = playerId,
                IsActive = true,
            };

            tournamentPlayer.Decks = deckIds
                .Select(deckId => new TournamentPlayerDeck
                {
                    DeckId = deckId,
                    TournamentPlayerId = tournamentPlayer.Id,
                    IsActive = true,
                })
                .ToList();

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
        {
            var test = await _dbContext.Tournament.ToListAsync();

            var result = await _dbContext
                .Tournament
                .AsNoTracking()
                .To<BaseTournamentViewModel>()
                .FirstOrDefaultAsync(t => t.Id == id);

            result.TournamentPlayer = await _dbContext.
                TournamentPlayer
                .AsNoTracking()
                .Where(tp => tp.TournamentId == id)
                .To<TournamentPlayerViewModel>()
                .ToListAsync();

            return result;
        }

        public async Task<Tournament> StartAsync(int tournamentId, string userId)
        {
            var tournament = await GetByIdAndUser(tournamentId, userId)
                .Include(t => t.Players)
                .FirstOrDefaultAsync();

            if (tournament is null)
            {
                throw new Exception("Tournament does not exist!");
            }

            tournament.HasStarted = true;
            await _dbContext.SaveChangesAsync();

            return tournament;
        }

        public async Task SetIdlePlayerAsync(Tournament tournament, string playerId)
        {
            tournament.IdlePlayerId = playerId;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Tournament> GetEntityById(int tournamentId)
             => await _dbContext.Tournament.FirstOrDefaultAsync(t => t.Id == tournamentId);

        private IQueryable<Tournament> GetByIdAndUser(int tournamentId, string userId)
            => _dbContext.Tournament
            .Where(t => t.OrganizerId == userId && t.Id == tournamentId);
    }
}
