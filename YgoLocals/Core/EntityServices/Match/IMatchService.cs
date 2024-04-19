namespace YgoLocals.Core.EntityServices.Match
{
    using YgoLocals.Data.Entities;
    using YgoLocals.Models.Match;

    public interface IMatchService : IBaseService<string, MatchViewModel>
    {
        Task<string> CreateAsync(string organizer);

        Task<IList<MatchViewModel>> GetAllAvaiable();

        Task JoinAsync(string matchId, string playerTwo);

        Task StartFromTournamentAsync(IList<Match> matches);

        Task<string> EndAsync(string matchId, string winnerId);

        Task<IList<MatchViewModel>> GetAllActiveByUser(string userId);

        Task<IList<MatchViewModel>> GetAllPastByUser(string userId);
    }
}
