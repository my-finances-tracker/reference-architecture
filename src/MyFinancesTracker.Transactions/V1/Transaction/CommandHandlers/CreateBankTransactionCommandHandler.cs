using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyFinancesTracker.Transactions.Contracts.V1.Transaction.Command;
using MyFinancesTracker.Transactions.Contracts.V1.Transaction.Dto;
using MyFinancesTracker.Transactions.Repositories;

namespace MyFinancesTracker.Transactions.V1.Transaction.CommandHandlers;
internal sealed class CreateBankTransactionCommandHandler : IRequestHandler<CreateBankTransactionCommand, CreateBankTransactionResponseDto>
{
    private readonly ITransactionRepository _transactionRepository;
    public CreateBankTransactionCommandHandler(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public Task<CreateBankTransactionResponseDto> Handle(CreateBankTransactionCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
