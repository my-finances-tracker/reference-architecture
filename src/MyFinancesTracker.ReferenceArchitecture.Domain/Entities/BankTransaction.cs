namespace MyFinancesTracker.ReferenceArchitecture.Domain.Entities;

public class BankTransaction : Transaction
{
    public required string Description { get; set; }
    public string? Sender { get; set; }
    public string? Receiver { get; set; }
}
