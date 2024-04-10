namespace MyFinancesTracker.Common.Crosscutting.Abstractions.EntityManagement;

public class ConcurrencyEntity
{
    public DateTime CreatedAt { get; set; }
    public string CreatedById { get; set; } = string.Empty;
    public string CreatedByName { get; set; } = string.Empty;
    public DateTime UpdatedAt { get; set; }
    public string UpdatedById { get; set; } = string.Empty;
    public string UpdatedByName { get; set; } = string.Empty;
}
