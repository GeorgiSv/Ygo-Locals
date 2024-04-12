namespace YgoLocals.Data.Entities.Base
{
    using YgoLocals.Data.Entities.Base.Contracts;
    using System;

    public abstract class BaseDeletableEntity<TKey> : BaseEntity<TKey>, IDeletableEntity
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
