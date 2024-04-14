namespace YgoLocals.Data.Entities
{
    public class TournamentPlayer
    {
        public string PlayerId { get; set; }

        public virtual User Player { get; set; }

        public int TournamentId { get; set; }

        public virtual Tournament Tournament { get; set; }
    }
}
