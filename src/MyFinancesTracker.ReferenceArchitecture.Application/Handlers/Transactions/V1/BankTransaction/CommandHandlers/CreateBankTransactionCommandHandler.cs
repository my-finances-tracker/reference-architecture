using MyFinancesTracker.Common.Crosscutting.Abstractions.ActionResult;
using MyFinancesTracker.Common.Crosscutting.Abstractions.Messaging;
using MyFinancesTracker.Common.Crosscutting.Interfaces;
using MyFinancesTracker.ReferenceArchitecture.Domain.Abstractions.Repositories;
using MyFinancesTracker.ReferenceArchitecture.Domain.Abstractions.UnitOfWork;
using MyFinancesTracker.Transactions.Contracts.V1.Transactions.Commands;
using MyFinancesTracker.Transactions.Contracts.V1.Transactions.Dto;

namespace MyFinancesTracker.Reference.Application.Handlers.Transactions.V1.BankTransaction.CommandHandlers;

internal sealed class CreateBankTransactionCommandHandler : ICommandHandler<CreateBankTransactionCommand, CreateBankTransactionResponseDto>
{
    private readonly ICreator<CreateBankTransactionRequestDto, ReferenceArchitecture.Domain.Entities.BankTransaction> _bankTransactionCreator;
    private readonly IBankTransactionRepository _bankTransactionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateBankTransactionCommandHandler(
        ICreator<CreateBankTransactionRequestDto, ReferenceArchitecture.Domain.Entities.BankTransaction>
            bankTransactionCreator,
        IBankTransactionRepository bankTransactionRepository,
        IUnitOfWork unitOfWork)
    {
        _bankTransactionCreator = bankTransactionCreator;
        _bankTransactionRepository = bankTransactionRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result<CreateBankTransactionResponseDto>> Handle(CreateBankTransactionCommand request, CancellationToken cancellationToken)
    {
        var bankTransaction = await _bankTransactionCreator.CreateAsync(request.Transaction);
        await _bankTransactionRepository.AddAsync(bankTransaction, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new CreateBankTransactionResponseDto
        {
            Id = bankTransaction.Id
        };
    }
}
