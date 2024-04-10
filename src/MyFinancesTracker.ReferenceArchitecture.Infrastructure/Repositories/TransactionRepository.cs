using MyFinancesTracker.Common.Crosscutting.Abstractions.EntityManagement;
using MyFinancesTracker.Common.Crosscutting.Attributes.ServiceLifetime;
using MyFinancesTracker.ReferenceArchitecture.Domain.Abstractions.Repositories;
using MyFinancesTracker.ReferenceArchitecture.Domain.Entities;
using MyFinancesTracker.ReferenceArchitecture.Infrastructure.Context;

namespace MyFinancesTracker.ReferenceArchitecture.Infrastructure.Repositories;

[ScopedLifetime]
internal sealed class BankTransactionRepository : Repository<BankTransaction, TransactionDbContext>, IBankTransactionRepository
{
    public BankTransactionRepository(TransactionDbContext dbContext) : base(dbContext)
    {
    }
}
