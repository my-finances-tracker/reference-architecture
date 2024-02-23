using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyFinancesTracker.Transactions.Context;

namespace MyFinancesTracker.Transactions.Extensions;
public static class TransactionsServiceCollectionExtensions
{
    public static IServiceCollection AddDataAccessTransactions(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<TransactionDbContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped<ITransactionDbContext>(p => p.GetRequiredService<TransactionDbContext>());

        return services;
    }

    public static IServiceCollection AddDataAccessInMemoryTransactions(this IServiceCollection services, string databaseName)
    {
        services.AddDbContext<TransactionDbContext>(options => options.UseInMemoryDatabase(databaseName));
        services.AddScoped<ITransactionDbContext>(p => p.GetRequiredService<TransactionDbContext>());

        return services;
    }
}
