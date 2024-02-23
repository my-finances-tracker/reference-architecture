namespace MyFinancesTracker.Common.Crosscutting.Attributes.Validation;

/// <summary>
/// Specifies is the DataAnnotationsValidator must skip this complex type property if there are validation errors in the current class.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class SkipRecursiveValidationAttribute : Attribute
{
}
