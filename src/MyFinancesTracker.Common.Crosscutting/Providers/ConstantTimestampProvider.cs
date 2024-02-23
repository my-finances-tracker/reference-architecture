using MyFinancesTracker.Common.Crosscutting.Interfaces;

namespace MyFinancesTracker.Common.Crosscutting.Providers;

public class ConstantTimestampProvider : ITimestampProvider
{
    public ConstantTimestampProvider(DateTime? timestamp = null)
    {
        UtcNow = timestamp ?? DateTime.UtcNow;
    }

    public DateTime UtcNow { get; }
}
