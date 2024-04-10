using Microsoft.EntityFrameworkCore;
using MyFinancesTracker.Common.Crosscutting.Abstractions.EntityManagement;
using MyFinancesTracker.ReferenceArchitecture.Domain.Entities;

namespace MyFinancesTracker.ReferenceArchitecture.Infrastructure.Context;

internal sealed class TransactionDbContext : DbContext, ITransactionDbContext
{
    public DbSet<BankTransaction> BankTransactions => Set<BankTransaction>();
    
    public TransactionDbContext(DbContextOptions<TransactionDbContext> options)
        : base(options)
    {
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateConcurrencyInfo();
        return await base.SaveChangesAsync(cancellationToken);
    }
    
    private void UpdateConcurrencyInfo()
    {
        var entities = ChangeTracker.Entries()
            .Where(e => e is
            {
                Entity: ConcurrencyEntity,
                State: EntityState.Added or EntityState.Modified
            });

        foreach (var entry in entities)
        {
            var entity = (ConcurrencyEntity)entry.Entity;

            if (entry.State == EntityState.Added)
            {
                entity.CreatedAt = DateTime.UtcNow;
            }

            entity.UpdatedAt = DateTime.UtcNow;
        }
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InfrastructureAssemblyReference).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
