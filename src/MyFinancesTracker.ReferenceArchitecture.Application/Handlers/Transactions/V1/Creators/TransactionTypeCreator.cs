using MyFinancesTracker.Common.Crosscutting.Attributes.ServiceLifetime;
using MyFinancesTracker.Common.Crosscutting.Interfaces;
using MyFinancesTracker.ReferenceArchitecture.Domain.Entities;

using contract_enums = MyFinancesTracker.Transactions.Contracts.V1.Transactions.Enums;
using domain_enums = MyFinancesTracker.ReferenceArchitecture.Domain.Entities;

namespace MyFinancesTracker.Reference.Application.Handlers.Transactions.V1.Creators;

[ScopedLifetime]
public class TransactionTypeCreator : ICreator<domain_enums.TransactionType, contract_enums.TransactionType>, ICreator<contract_enums.TransactionType, domain_enums.TransactionType>
{
    public ValueTask<contract_enums.TransactionType> CreateAsync(TransactionType source)
    {
        var result = source switch
        {
            domain_enums.TransactionType.Incoming => contract_enums.TransactionType.Incoming,
            domain_enums.TransactionType.Outgoing => contract_enums.TransactionType.Outgoing,
            _ => throw new NotSupportedException($"FileType {source} is unknown")
        };

        return new ValueTask<contract_enums.TransactionType>(result);
    }

    public ValueTask<domain_enums.TransactionType> CreateAsync(MyFinancesTracker.Transactions.Contracts.V1.Transactions.Enums.TransactionType source)
    {
        var result = source switch
        {
            contract_enums.TransactionType.Incoming => domain_enums.TransactionType.Incoming,
            contract_enums.TransactionType.Outgoing => domain_enums.TransactionType.Outgoing,
            _ => throw new NotSupportedException($"FileType {source} is unknown")
        };

        return new ValueTask<domain_enums.TransactionType>(result);
    }
}
