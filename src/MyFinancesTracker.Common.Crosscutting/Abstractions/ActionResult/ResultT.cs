﻿namespace MyFinancesTracker.Common.Crosscutting.Abstractions.ActionResult;

public class Result<TValue> : Result
{
    private readonly TValue? _value;

    protected internal Result(
        TValue? value,
        bool isSuccess,
        ErrorResult errorResult)
        : base(isSuccess, errorResult)
    {
        _value = value;
    }

    public TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("The value of a failure result can not be accessed.");

    public static implicit operator Result<TValue>(TValue? value) => Create(value);

}
