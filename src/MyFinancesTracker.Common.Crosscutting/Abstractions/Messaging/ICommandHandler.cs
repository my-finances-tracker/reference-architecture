using MediatR;
using MyFinancesTracker.Common.Crosscutting.Abstractions.ActionResult;

namespace MyFinancesTracker.Common.Crosscutting.Abstractions.Messaging;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand;

public interface ICommandHandler<TCommand, TResponse>
    : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>;
