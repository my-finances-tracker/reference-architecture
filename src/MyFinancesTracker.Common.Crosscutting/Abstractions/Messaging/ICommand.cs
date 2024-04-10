using MediatR;
using MyFinancesTracker.Common.Crosscutting.Abstractions.ActionResult;

namespace MyFinancesTracker.Common.Crosscutting.Abstractions.Messaging;

public interface ICommand : IRequest<Result>;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>;
