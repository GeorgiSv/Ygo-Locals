namespace YgoLocals.Data.Entities
{
    using YgoLocals.Data.Entities.Base;

    public class Tournament : BaseDeletableEntity<int>
    {
        public Tournament()
        {
            Mathces = new List<Match>();
            Players = new List<TournamentPlayer>();
        }

        public string OrganizerId { get; set; }

        public virtual User Organizer { get; set; }

        public DateTime StartedOn { get; set; }

        public DateTime FinishedOn { get; set; }

        public bool HasStarted { get; set; }

        public bool HasFinished { get; set; }

        public int MaxPlayers { get; set; }

        public int TournamentTypeId { get; set; }

        public TournamentType TournamentType { get; set; }

        public IList<TournamentPlayer> Players { get; set; }

        public IList<Match> Mathces { get; set; }
    }
}
