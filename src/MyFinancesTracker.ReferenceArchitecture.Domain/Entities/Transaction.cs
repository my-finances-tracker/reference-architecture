using MyFinancesTracker.Common.Crosscutting.Abstractions.EntityManagement;

namespace MyFinancesTracker.ReferenceArchitecture.Domain.Entities;

public abstract class Transaction : Entity
{
    public required double Amount { get; set; }
    public required string Source { get; set; } // TODO: maybe this should come from a different source.
    public required TransactionType TransactionType { get; set; }
}
