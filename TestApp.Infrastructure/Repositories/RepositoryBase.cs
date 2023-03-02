using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestApp.Domain.Abstraction.Repositories;
using TestApp.Domain.Model.Abstraction.Entities;

namespace TestApp.Infrastructure.Repositories
{
    public abstract class RepositoryBase<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : class, IEntity<TId>
        where TId : struct
    {
        private readonly DbContext _dbContext;
        protected readonly DbSet<TEntity>? _dbSet;

        protected DbSet<TEntity> DbSet => _dbContext.Set<TEntity>();
        protected virtual IQueryable<TEntity> BaseQuery => DbSet;

        public RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async virtual ValueTask<TEntity> GetByIdAsync(TId id, CancellationToken cancellation = default)
        {
            var result = await BaseQuery.SingleAsync(entity => entity.Id.Equals(id), cancellation);

            return result;
        }

        public async virtual ValueTask<TEntity?> FindByIdAsync(TId id, CancellationToken cancellation = default)
        {
            var result = await BaseQuery.SingleOrDefaultAsync(entity => entity.Id.Equals(id), cancellation);

            return result;
        }

        public async virtual ValueTask<TEntity> FirstAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellation = default)
        {
            if (predicate is not null)
            {
                return await BaseQuery.FirstAsync(predicate, cancellation);
            }

            return await BaseQuery.FirstAsync(cancellation);
        }

        public async virtual ValueTask<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellation = default)
        {
            if (predicate is not null)
            {
                return await BaseQuery.FirstOrDefaultAsync(predicate, cancellation);
            }

            return await BaseQuery.FirstOrDefaultAsync(cancellation);
        }

        public async virtual ValueTask<List<TEntity>> AllAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellation = default)
        {
            if (predicate is not null)
            {
                return await BaseQuery.Where(predicate).ToListAsync(cancellation);
            }

            return await BaseQuery.ToListAsync(cancellation);
        }

        public async virtual ValueTask<TEntity> AddAsync(TEntity entity, CancellationToken cancellation = default)
        {
            var result = await DbSet.AddAsync(entity);

            return result.Entity;
        }

        public virtual void Remove(TEntity entity, CancellationToken cancellation = default)
        {
            DbSet.Remove(entity);
        }
    }
}
