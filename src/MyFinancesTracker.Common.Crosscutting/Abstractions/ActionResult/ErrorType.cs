namespace MyFinancesTracker.Common.Crosscutting.Abstractions.ActionResult;

public enum ErrorType
{
    Validation = 0,
    NotFound = 1,
    Conflict = 2,
    InternalServerError = 3,
    None = 4
}
