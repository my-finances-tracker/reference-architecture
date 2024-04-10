using MediatR;
using MyFinancesTracker.Common.Crosscutting.Abstractions.ActionResult;

namespace MyFinancesTracker.Common.Crosscutting.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
