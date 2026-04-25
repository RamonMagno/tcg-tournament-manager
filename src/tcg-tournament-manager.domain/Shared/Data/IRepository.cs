namespace tcg_tournament_manager.domain.Shared.Data
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);

        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);

        Task Insert(params T[] entities);
        Task Update(params T[] entities);
        Task Delete(params T[] entities);
    }
}
