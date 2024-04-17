namespace YgoLocals.Models.Tournament
{
    using YgoLocals.Infrastructure.Automapper;
    using YgoLocals.Data.Entities;
    using YgoLocals.Models.TournamentPlayer;

    public class BaseTournamentViewModel : IMapFrom<Tournament>
    {
        public BaseTournamentViewModel()
        {
            TournamentPlayer = new List<TournamentPlayerViewModel>();
        }
        public int Id { get; set; }

        public User Organizer { get; set; }

        public TournamentTypeViewModel TournamentType { get; set; }

        public IList<TournamentPlayerViewModel> TournamentPlayer { get; set; }

        public int MaxPlayers { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
