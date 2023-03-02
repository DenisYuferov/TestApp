using System.Linq.Expressions;

namespace TestApp.Domain.Abstraction.Repositories
{
    public interface IRepository<TEntity, TId>
    {
        ValueTask<TEntity> GetByIdAsync(TId id, CancellationToken cancellation = default);
        ValueTask<TEntity?> FindByIdAsync(TId id, CancellationToken cancellation = default);
        ValueTask<TEntity> FirstAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellation = default);
        ValueTask<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellation = default);
        ValueTask<List<TEntity>> AllAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellation = default);
        ValueTask<TEntity> AddAsync(TEntity entity, CancellationToken cancellation = default);
        void Remove(TEntity entity, CancellationToken cancellation = default);
    }
}
