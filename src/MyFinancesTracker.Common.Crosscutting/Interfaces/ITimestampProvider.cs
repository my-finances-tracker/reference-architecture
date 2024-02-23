namespace MyFinancesTracker.Common.Crosscutting.Interfaces;

public interface ITimestampProvider
{
    public DateTime UtcNow { get; }
}
