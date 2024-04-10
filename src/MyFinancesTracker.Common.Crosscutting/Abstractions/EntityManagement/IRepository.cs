using Microsoft.EntityFrameworkCore;

namespace MyFinancesTracker.Common.Crosscutting.Abstractions.EntityManagement;

public interface IRepository<TEntity>
    where TEntity : Entity
{
    /// <summary>
    /// Find an entity by its id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="includeFunc">Includes the related Entities</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TEntity?> FindByIdAsync(
        Guid id,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? includeFunc = null,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<TEntity>> GetAllAsync(
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? includeFunc = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Add an entity to the database
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update an entity in the database
    /// </summary>
    /// <param name="entity"></param>
    void Update(TEntity entity);

    /// <summary>
    /// Remove an entity from the database
    /// </summary>
    /// <param name="entity"></param>
    void Remove(TEntity entity);
}
