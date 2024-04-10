namespace MyFinancesTracker.Common.Crosscutting.Abstractions.ActionResult;

public class Result
{
    protected Result(
        bool isSuccess,
        ErrorResult errorResult)
    {
        switch (isSuccess)
        {
            case true when errorResult != ErrorResult.None:
                throw new InvalidOperationException();
            case false when errorResult == ErrorResult.None:
                throw new InvalidOperationException();
            default:
                IsSuccess = isSuccess;
                ErrorResult = errorResult;
                break;
        }
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public ErrorResult ErrorResult { get; }

    public static Result Success() => new(true, ErrorResult.None);

    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, ErrorResult.None);

    public static Result Failure(ErrorResult errorResult) => new(false, errorResult);

    public static Result<TValue> Failure<TValue>(ErrorResult errorResult) => new(default, false, errorResult);
    public static Result NotFound(Type entityType) => Failure(ErrorResult.NotFound(entityType));
    public static Result<TValue> NotFound<TValue>(Type entityType) => Failure<TValue>(ErrorResult.NotFound(entityType));
    public static Result<TValue> Create<TValue>(TValue? value) => value is not null ? Success(value) : Failure<TValue>(ErrorResult.NullValue);
}
