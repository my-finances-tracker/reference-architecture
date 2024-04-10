namespace MyFinancesTracker.ReferenceArchitecture.Domain.Abstractions.UnitOfWork;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
