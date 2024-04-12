namespace YgoLocals.Data.Entities.Base.Contracts
{
    using System;

    public interface IDeletableEntity
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
