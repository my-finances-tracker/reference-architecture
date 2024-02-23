using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFinancesTracker.Transactions.Contracts.V1.Constants;

namespace MyFinancesTracker.Transactions.Api.Controllers.V1.Transaction;
[Route(TransactionRouteConstants.Transaction)]
[ApiController]
public class TransactionCommandController : ControllerBase
{
    private readonly ISender _sender;

    public TransactionCommandController(ISender sender)
    {
        _sender = sender;
    }
}
