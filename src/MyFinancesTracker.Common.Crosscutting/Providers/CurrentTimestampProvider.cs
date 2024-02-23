using MyFinancesTracker.Common.Crosscutting.Attributes.ServiceLifetime;
using MyFinancesTracker.Common.Crosscutting.Interfaces;

namespace MyFinancesTracker.Common.Crosscutting.Providers;

[ScopedLifetime]
public class CurrentTimestampProvider : ITimestampProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
