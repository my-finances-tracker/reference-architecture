using MediatR;
using MyFinancesTracker.Common.Crosscutting.Abstractions.ActionResult;

namespace MyFinancesTracker.Common.Crosscutting.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;
