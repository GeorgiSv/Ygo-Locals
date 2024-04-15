namespace YgoLocals.Models.Deck
{
    using YgoLocals.Infrastructure.Automapper;
    using YgoLocals.Data.Entities;

    public class DeckViewModel : IMapFrom<Deck>
    {
        public string Name { get; set; }

        public User User { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
