using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFinancesTracker.ReferenceArchitecture.Domain.Entities;
using MyFinancesTracker.ReferenceArchitecture.Infrastructure.Constants;

namespace MyFinancesTracker.ReferenceArchitecture.Infrastructure.Configuration;

public class BankTransactionConfiguration : IEntityTypeConfiguration<BankTransaction>
{
    public void Configure(EntityTypeBuilder<BankTransaction> builder)
    {
        builder.ToTable(DbConstants.BankTransaction, DbConstants.Namespace);

        builder.HasKey(entity => entity.Id);
    }
}
