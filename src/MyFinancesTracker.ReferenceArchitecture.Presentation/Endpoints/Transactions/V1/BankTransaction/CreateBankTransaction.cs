using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyFinancesTracker.Transactions.Contracts.V1.Constants;
using MyFinancesTracker.Transactions.Contracts.V1.Transactions.Commands;

namespace MyFinancesTracker.ReferenceArchitecture.Presentation.Endpoints.Transactions.V1.BankTransaction;

public class CreateBankTransaction(ISender sender) : EndpointBaseAsync
    .WithRequest<CreateBankTransactionCommand>
    .WithActionResult
{
    
    [HttpPost($"{TransactionRouteConstants.Transaction}/{TransactionRouteConstants.BankTransaction}")]
    public override async Task<ActionResult> HandleAsync([FromBody] CreateBankTransactionCommand request, CancellationToken cancellationToken = new())
    {
        var result = await sender.Send(request, cancellationToken);
        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.ErrorResult);
    }
}
