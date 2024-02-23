using Microsoft.EntityFrameworkCore;
using MyFinancesTracker.Transactions.DbModel;

namespace MyFinancesTracker.Transactions.Context;
internal interface ITransactionDbContext
{
    DbSet<BankTransaction> BankTransactions { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
