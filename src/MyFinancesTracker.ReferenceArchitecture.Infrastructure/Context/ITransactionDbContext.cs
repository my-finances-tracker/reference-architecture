using Microsoft.EntityFrameworkCore;
using MyFinancesTracker.ReferenceArchitecture.Domain.Entities;

namespace MyFinancesTracker.ReferenceArchitecture.Infrastructure.Context;
internal interface ITransactionDbContext
{
    DbSet<BankTransaction> BankTransactions { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
