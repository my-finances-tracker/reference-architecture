using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace MyFinancesTracker.Transactions.Context;
internal sealed class TransactionDesignTimeDbContextFactory : IDesignTimeDbContextFactory<TransactionDbContext>
{
    public TransactionDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TransactionDbContext>();

        var connectionString = "Host=localhost;Port=5432;Username=postgres;Password=mysecretpassword;Database=MyFinancesTracker";

        optionsBuilder.UseNpgsql(connectionString);
        return new TransactionDbContext(optionsBuilder.Options);
    }
}
