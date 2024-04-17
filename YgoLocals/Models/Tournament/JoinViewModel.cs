namespace YgoLocals.Models.Tournament
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using YgoLocals.Models.Deck;

    public class JoinViewModel
    {
        public string SelectedDeckId { get; set; }

        public IList<SelectListItem> Decks { get; set; }

        public int TournamentId { get; set; }

        public BaseTournamentViewModel Tournament { get; set; }
    }
}
