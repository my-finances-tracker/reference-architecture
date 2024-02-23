namespace MyFinancesTracker.Common.Crosscutting.Extensions;

public static class ObjectExtensions
{
    public static object? GetPropertyValue(this object o, string propertyName)
    {
        object? objValue = null;

        var propertyInfo = o.GetType().GetProperty(propertyName);
        if (propertyInfo != null)
        {
            objValue = propertyInfo.GetValue(o, null);
        }

        return objValue;
    }
}
