namespace MyFinancesTracker.Common.Crosscutting.Abstractions.ActionResult;

public sealed record ErrorResult(
    string Code,
    string Message,
    ErrorType ErrorType)
{
    public static readonly ErrorResult None = new(string.Empty, string.Empty, ErrorType.None);
    public static readonly ErrorResult NullValue = new("Error.NullValue", "The specified result value is null.", ErrorType.NotFound);
    public static ErrorResult NotFound(Type entityType) =>
        new ErrorResult("Error.NotFound", $"The specified {entityType.Name} was not found.", ErrorType.NotFound);
}
