// namespace YgoLocals.Core.ProcessorServices
// {
//     using YgoLocals.Core.EntityServices.Match;
//     using YgoLocals.Core.EntityServices.Tournament;
//     using YgoLocals.Core.EntityServices.TournamentPlayer;
//     using YgoLocals.Data.Entities;

//     public class TournamentProcessorService
//     {
//         private readonly ITournamentService _tournamentService;
//         private readonly ITournamentPlayerService _tournamentPlayerService;
//         private readonly IMatchService _matchService;

//         public TournamentProcessorService(
//             ITournamentService tournamentService, 
//             ITournamentPlayerService tournamentPlayerService,
//             IMatchService matchService)
//         {
//             _tournamentService = tournamentService;
//             _tournamentPlayerService = tournamentPlayerService;
//             _matchService = matchService;
//         }

//         public async Task<List<Match>> ProcessMatchesStart(Tournament tournament)
//         {
//             if (!tournament.Players.Any())
//             {
//                 return null;
//             }

//             List<Match> matches = new();
//             //var players = await _tournamentPlayerService.GetActivePlayersAsync(tournament);
//             var players = tournament.Players.Where(tp => tp.IsActive).ToList();
//             Shuffle(players);

//             if (tournament.IdlePlayerId != null)
//             {
//                 players.Add(tournament.IdlePlayer);
//             }

//             for (int i = 0; i < players.Count - 1; i += 2)
//             {
//                 var playerOne = players[i];
//                 var playerTwo = players[i + 1];

//                 var match = new Match()
//                 {
//                     PlayerOne = playerOne.Player,
//                     PlayerOneDeckId = playerOne.Decks.FirstOrDefault(d => d.IsActive).Deck.Id,
//                     PlayerTwo = playerTwo.Player,
//                     PlayerTwoDeckId = playerTwo.Decks.FirstOrDefault(d => d.IsActive).Deck.Id,
//                     TournamentId = tournament.Id,
//                 };

//                 matches.Add(match);
//             }

//             await _matchService.StartFromTournamentAsync(matches);

//             // If there's an odd number of players, leave the last player without an opponent
//             if (players.Count % 2 != 0)
//             {
//                 var notPlayingPlayer = players[players.Count - 1];
//                 await _tournamentService.SetIdlePlayerAsync(tournament, notPlayingPlayer.Id);
//             }

//             return matches;
//         }

//         private void Shuffle<T>(List<T> list)
//         {
//             Random rng = new Random();
//             int n = list.Count;
//             while (n > 1)
//             {
//                 n--;
//                 int k = rng.Next(n + 1);
//                 T value = list[k];
//                 list[k] = list[n];
//                 list[n] = value;
//             }
//         }
//     }
// }
