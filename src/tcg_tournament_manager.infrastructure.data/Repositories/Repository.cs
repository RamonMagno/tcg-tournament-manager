using tcg_tournament_manager.domain.Shared.Data;
using tcg_tournament_manager.infrastructure.data.Context;

namespace tcg_tournament_manager.infrastructure.data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public TCGTournamentManagerContext _context { get; set; }

        public Repository(TCGTournamentManagerContext context)
        {
            _context = context;
        }

        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await Task.CompletedTask;
        }

        public async Task Delete(params T[] entities)
        {
            _context.Set<T>().RemoveRange(entities);
            await Task.CompletedTask;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Insert(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task Insert(params T[] entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await Task.CompletedTask;
        }

        public async Task Update(params T[] entities)
        {
            _context.Set<T>().UpdateRange(entities);
            await Task.CompletedTask;
        }
    }
}
