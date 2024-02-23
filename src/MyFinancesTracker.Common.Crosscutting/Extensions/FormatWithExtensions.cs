using System.Globalization;
using MyFinancesTracker.Common.Crosscutting.Resources;

namespace MyFinancesTracker.Common.Crosscutting.Extensions;

public static class FormatWithExtensions
{
    public static string FormatWith(this string targetString, params object[] args)
    {
        if (string.IsNullOrWhiteSpace(targetString))
        {
            throw new ArgumentException(ExceptionMessages.IsNullOrWhiteSpace, nameof(targetString));
        }

        if (args.Any(arg => arg is null))
        {
            throw new ArgumentNullException(ExceptionMessages.SomeArgumentNull);
        }

        return string.Format(CultureInfo.InvariantCulture, targetString, args);
    }
}
