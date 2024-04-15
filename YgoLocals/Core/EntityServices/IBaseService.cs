namespace YgoLocals.Core.EntityServices
{
    public interface IBaseService<TKey, TValue>
    {
        Task<TValue> GetByIdAsync(TKey id);

        Task<bool> DeleteAsync(TKey id);
    }
}
