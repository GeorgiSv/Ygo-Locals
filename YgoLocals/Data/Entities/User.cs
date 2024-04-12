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

        public IList<Deck> Decks { get; set; }
    }
}
