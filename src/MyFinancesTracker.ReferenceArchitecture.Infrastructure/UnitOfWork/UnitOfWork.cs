using MyFinancesTracker.Common.Crosscutting.Attributes.ServiceLifetime;
using MyFinancesTracker.ReferenceArchitecture.Domain.Abstractions.UnitOfWork;
using MyFinancesTracker.ReferenceArchitecture.Infrastructure.Context;

namespace MyFinancesTracker.ReferenceArchitecture.Infrastructure.UnitOfWork;

[ScopedLifetime]
internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly ITransactionDbContext _dbContext;

    public UnitOfWork(ITransactionDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}
