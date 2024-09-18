// namespace YgoLocals.Data.Entities
// {
//     using YgoLocals.Data.Entities.Base;

//     public class TournamentPlayer : BaseDeletableEntity<string>
//     {
//         public TournamentPlayer()
//         {
//             Id = Guid.NewGuid().ToString();
//             Decks = new List<TournamentPlayerDeck>();
//         }

//         public string PlayerId { get; set; }

//         public virtual User Player { get; set; }

//         public int TournamentId { get; set; }

//         public virtual Tournament Tournament { get; set; }

//         public bool HasPlayed { get; set; }

//         public bool IsActive { get; set; }

//         public bool IsIdle { get; set; }

//         public bool HasWin { get; set; }

//         public IList<TournamentPlayerDeck> Decks { get; set; }
//     }
// }
