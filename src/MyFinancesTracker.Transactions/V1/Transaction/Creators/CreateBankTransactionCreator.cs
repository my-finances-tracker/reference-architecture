using MyFinancesTracker.Common.Crosscutting.Interfaces;
using MyFinancesTracker.Transactions.Contracts.V1.Transaction.Dto;
using MyFinancesTracker.Transactions.DbModel;

namespace MyFinancesTracker.Transactions.V1.Transaction.Creators;
internal sealed class CreateBankTransactionCreator : ICreator<CreateBankTransactionRequestDto, DbModel.BankTransaction>
{
    public ValueTask<BankTransaction> CreateAsync(CreateBankTransactionRequestDto source)
    {
        throw new NotImplementedException();
    }
}
