namespace YgoLocals.Core.EntityServices.Match
{
    using YgoLocals.Data.Entities;

    public interface IMatchService : IBaseService<string, Match>
    {
        Task<string> StartAsync(string playerOneId, string playerTwoId, int? tournamentId);

        Task<string> EndAsync(string matchId, string winnerId);

        Task<IList<Match>> GetAllByUser(string userId);
    }
}
