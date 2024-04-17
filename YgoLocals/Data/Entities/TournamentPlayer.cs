namespace YgoLocals.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class TournamentPlayer
    {
        public TournamentPlayer()
        {
            Id = Guid.NewGuid().ToString();
            Decks = new List<TournamentPlayerDeck>();
        }

        [Key]
        public string Id { get; set; }

        public string PlayerId { get; set; }

        public virtual User Player { get; set; }

        public int TournamentId { get; set; }

        public virtual Tournament Tournament { get; set; }

        public bool HasPlayed { get; set; }

        public bool HasWin { get; set; }

        public IList<TournamentPlayerDeck> Decks { get; set; }
    }
}
