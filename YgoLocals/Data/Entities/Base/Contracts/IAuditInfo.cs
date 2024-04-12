namespace YgoLocals.Data.Entities.Base.Contracts
{
    using System;

    public interface IAuditInfo
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
