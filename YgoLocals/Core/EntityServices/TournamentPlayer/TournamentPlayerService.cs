// namespace YgoLocals.Core.EntityServices.TournamentPlayer
// {
//     using System.Threading.Tasks;
//     using Microsoft.EntityFrameworkCore;
//     using YgoLocals.Data;
//     using YgoLocals.Data.Entities;

//     public class TournamentPlayerService : ITournamentPlayerService
//     {
//         private readonly ApplicationDbContext _dbContext;

//         public TournamentPlayerService(ApplicationDbContext dbContext)
//         {
//             _dbContext = dbContext;
//         }

//         public async Task<List<TournamentPlayer>> GetActivePlayersAsync(int tournamentId)
//             => await _dbContext.TournamentPlayer
//             .Where(tp => tp.TournamentId == tournamentId && tp.IsActive)
//             .ToListAsync();
//     }
// }
