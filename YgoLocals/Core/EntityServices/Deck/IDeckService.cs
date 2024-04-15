namespace YgoLocals.Core.EntityServices.Deck
{
    using YgoLocals.Data.Entities;
    using YgoLocals.Models.Deck;

    public interface IDeckService : IBaseService<string, Deck>
    {
        Task<string> CreateAsync(string userId, string name);

        Task<bool> EditAsync(string id, string userId, string name);

        Task<IList<DeckViewModel>> GetAllByUserAsync(string userId);

        Task AddCardsAsync(IList<string> cardNames);
    }
}
