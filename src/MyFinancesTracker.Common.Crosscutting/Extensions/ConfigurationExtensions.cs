using Microsoft.Extensions.Configuration;

namespace MyFinancesTracker.Common.Crosscutting.Extensions;

public static class ConfigurationExtensions
{
    public static string GetRequiredString(this IConfiguration configuration, string key)
    {
        ArgumentNullException.ThrowIfNull(configuration);
        ArgumentNullException.ThrowIfNull(key);

        var value = configuration[key];
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidOperationException($"Config error: missing config value for key [{key}]");
        }
        return value;
    }

    public static bool GetRequiredBool(this IConfiguration configuration, string key)
    {
        ArgumentNullException.ThrowIfNull(configuration);
        ArgumentNullException.ThrowIfNull(key);

        var value = configuration[key];
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidOperationException($"Config error: missing config value for key [{key}]");
        }
        
        if (!bool.TryParse(value, out var result))
        {
            throw new InvalidOperationException(
                $"Config error: invalid config value for key [{key}], the value should be of type {nameof(Boolean)}");
        }
        
        return result;
    }

    public static string GetRequiredConnectionString(this IConfiguration configuration, string name)
    {
        ArgumentNullException.ThrowIfNull(configuration);
        ArgumentNullException.ThrowIfNull(name);

        var value = configuration.GetConnectionString(name);
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidOperationException($"Config error: missing config value for connection string with name [{name}]");
        }
        return value;
    }
}
