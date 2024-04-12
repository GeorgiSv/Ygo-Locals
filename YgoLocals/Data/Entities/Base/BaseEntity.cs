namespace YgoLocals.Data.Entities.Base
{
    using YgoLocals.Data.Entities.Base.Contracts;
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseEntity<TKey> : IAuditInfo
    {
        [Key]
        [Required]
        public TKey Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
