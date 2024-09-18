namespace YgoLocals.Data.Entities
{
    using System;
    using Microsoft.AspNetCore.Identity;
    using YgoLocals.Data.Entities.Base.Contracts;

    public class User : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            Decks = new List<Deck>();
        }

        public int WinsCount { get; set; }

        public int LoossesCount { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        //public virtual IList<TournamentPlayer> Tournaments { get; set; }

        public virtual IList<Deck> Decks { get; set; }

        //public virtual ICollection<Match> PlayerOneMatches { get; set; }

        //public virtual ICollection<Match> PlayerTwoMatches { get; set; }
    }
}
