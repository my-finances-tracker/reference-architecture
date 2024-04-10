using System.Runtime.Versioning;
using MyFinancesTracker.Common.Crosscutting.Attributes.ServiceLifetime;
using MyFinancesTracker.Common.Crosscutting.Interfaces;
using MyFinancesTracker.Transactions.Contracts.V1.Transactions.Dto;
using MyFinancesTracker.Transactions.Contracts.V1.Transactions.Enums;

using domain_entities = MyFinancesTracker.ReferenceArchitecture.Domain.Entities;

namespace MyFinancesTracker.Reference.Application.Handlers.Transactions.V1.BankTransaction.Creators;

[ScopedLifetime]
public class CreateBankTransactionCreator : ICreator<CreateBankTransactionRequestDto, domain_entities.BankTransaction>
{
    private readonly ICreator<TransactionType, ReferenceArchitecture.Domain.Entities.TransactionType>
        _transactionTypeCreator;

    public CreateBankTransactionCreator(ICreator<TransactionType, domain_entities.TransactionType> transactionTypeCreator)
    {
        _transactionTypeCreator = transactionTypeCreator;
    }
    
    public async ValueTask<domain_entities.BankTransaction> CreateAsync(CreateBankTransactionRequestDto source)
    {
        var result = new ReferenceArchitecture.Domain.Entities.BankTransaction
        {
            Amount = source.Amount,
            Source = source.Source,
            TransactionType = await _transactionTypeCreator.CreateAsync(source.transactionType),
            Description = source.Description
        };

        return result;
    }
}
