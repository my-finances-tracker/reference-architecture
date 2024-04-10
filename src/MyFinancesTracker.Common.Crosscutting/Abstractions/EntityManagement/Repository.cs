using Microsoft.EntityFrameworkCore;

namespace MyFinancesTracker.Common.Crosscutting.Abstractions.EntityManagement;

public abstract class Repository<TEntity, TContext> : IRepository<TEntity>
    where TEntity : Entity
    where TContext : DbContext
{
#pragma warning disable CA1051
    protected readonly TContext DbContext;
#pragma warning restore CA1051

    protected Repository(TContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<TEntity?> FindByIdAsync(
            Guid id, Func<IQueryable<TEntity>,
            IQueryable<TEntity>>? includeFunc = null,
        CancellationToken cancellationToken = default)
    {
        var query = DbContext.Set<TEntity>().AsQueryable();

        // Apply additional includes if provided
        if (includeFunc != null)
        {
            query = includeFunc(query);
        }

        var entity = await query.FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);

        if (entity is null)
        {
            return null;
        }

        DbContext.Attach(entity);
        return entity;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>>? includeFunc = null,
        CancellationToken cancellationToken = default)
    {
        var query = DbContext.Set<TEntity>().AsQueryable();

        // Apply additional includes if provided
        if (includeFunc != null)
        {
            query = includeFunc(query);
        }

        var entities = await query.ToListAsync(cancellationToken);

        return entities;
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await DbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
    }

    public void Update(TEntity entity)
    {
        DbContext.Set<TEntity>().Update(entity);
    }

    public void Remove(TEntity entity)
    {
        DbContext.Set<TEntity>().Remove(entity);
    }
}
