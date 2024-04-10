namespace MyFinancesTracker.Common.Crosscutting.Abstractions.EntityManagement;
/// <summary>
/// Base Entity class for all entities in the system.
/// This class ensures that all entities have the same properties.
/// The CreatedAt, CreatedById, CreatedByName, UpdatedAt, UpdatedById, UpdatedByName properties are used to track the creation and modification of the entity.
/// They are also necessary for concurrency control. 
/// </summary>
public abstract class Entity : ConcurrencyEntity
{
    public Guid Id { get; } = Guid.NewGuid();
}
