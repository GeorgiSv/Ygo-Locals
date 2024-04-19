namespace YgoLocals.Models.Match
{
    using YgoLocals.Data.Entities;
    using YgoLocals.Infrastructure.Automapper;

    public class MatchViewModel : IMapFrom<Match>
    {
        public string Id { get; set; }

        public string PlayerOneId { get; set; }

        public User PlayerOne { get; set; }

        public string PlayerTwoId { get; set; }

        public User PlayerTwo { get; set; }

        public string WinnerId { get; set; }

        public User Winner { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
