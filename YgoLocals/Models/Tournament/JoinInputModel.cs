namespace YgoLocals.Models.Tournament
{
    public class JoinInputModel
    {
        public IList<string> SelectedDeckId { get; set; }

        public int TournamentId { get; set; }
    }
}
