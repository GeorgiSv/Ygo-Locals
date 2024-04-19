namespace YgoLocals.Models.TournamentPlayer
{
    using YgoLocals.Infrastructure.Automapper;
    using YgoLocals.Data.Entities;

    public class TournamentPlayerViewModel : IMapFrom<TournamentPlayer>
    {
        public TournamentPlayerViewModel()
        {
            Decks = new List<TournamentPlayerDeckViewModel>();
        }

        public virtual User Player { get; set; }

        public bool HasPlayed { get; set; }

        public bool HasWin { get; set; }

        public bool IsActive { get; set; }

        public IList<TournamentPlayerDeckViewModel> Decks { get; set; }
    }
}
