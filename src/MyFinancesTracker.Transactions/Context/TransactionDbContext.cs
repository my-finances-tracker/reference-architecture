using Microsoft.EntityFrameworkCore;
using MyFinancesTracker.Transactions.DbModel;

namespace MyFinancesTracker.Transactions.Context;
internal sealed class TransactionDbContext : DbContext, ITransactionDbContext
{
    public DbSet<BankTransaction> BankTransactions => Set<BankTransaction>();

    public TransactionDbContext(DbContextOptions<TransactionDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<DbModel.Transaction>().HasDiscriminator();

        PreventDatabaseCascadeDeletes(modelBuilder);
    }

    /// <summary>
    /// Get all FK releations and set then to ClientCascade instead of (database) Cascade 
    /// This will fix: Introducing FOREIGN KEY constraint 'FK_Document_User_UploadedByUserId' on table 'Document' may cause cycles or multiple cascade paths.
    /// </summary>
    /// <param name="modelBuilder">ModelBuilder</param>
    private static void PreventDatabaseCascadeDeletes(ModelBuilder modelBuilder)
    {
        // TODO: Promote to helper function in common?
        // TODO: Is er een manier om dit te doen speficiek voor een model of iets anders beters ipv alles?
        // Source: https://learn.microsoft.com/en-us/ef/core/saving/cascade-delete
        var cascadeFKs = modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetForeignKeys()).Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

        foreach (var fk in cascadeFKs)
        {
            fk.DeleteBehavior = DeleteBehavior.ClientCascade;
        }
    }
}
