namespace YgoLocals.Models.Tournament
{
    using YgoLocals.Infrastructure.Automapper;
    using YgoLocals.Data.Entities;

    public class BaseTournamentViewModel : IMapFrom<Tournament>
    {
        public int Id { get; set; }

        public User Organizer { get; set; }

        public TournamentTypeViewModel TournamentType { get; set; }

        public int MaxPlayers { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
