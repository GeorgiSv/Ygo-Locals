namespace YgoLocals.Core.EntityServices.Deck
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using YgoLocals.Data;
    using YgoLocals.Data.Entities;
    using YgoLocals.Models.Deck;
    using YgoLocals.Infrastructure.Automapper;

    public class DeckService : IDeckService
    {
        private readonly ApplicationDbContext _dbContext;

        public DeckService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> CreateAsync(string userId, string name)
        {
            var deck = new Deck()
            {
                Name = name,
                UserId = userId,
            };

            _dbContext.Deck.Add(deck);
            await _dbContext.SaveChangesAsync();

            return deck.Id;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var deck = await GetByIdAsync(id);
            if (deck is null)
            {
                return false;
            }

            _dbContext.Deck.Remove(deck);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditAsync(string id, string userId, string name)
        {
            var deck = await GetByIdAsync(id);
            if (deck is null)
            {
                return false;
            }

            if (deck.UserId != userId)
            {
                return false;
            }

            deck.Name = name;

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Deck> GetByIdAsync(string id)
            => await _dbContext.Deck.FirstOrDefaultAsync(d => d.Id == id);

        public async Task<IList<DeckViewModel>> GetAllByUserAsync(string userId)
            => await _dbContext.Deck
            .Where(d => d.UserId == userId)
            .AsNoTracking()
            .To<DeckViewModel>()
            .ToListAsync();

        public Task AddCardsAsync(IList<string> cardNames)
        {
            throw new NotImplementedException();
        }
    }
}
