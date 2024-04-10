using MyFinancesTracker.Common.Crosscutting.Abstractions.EntityManagement;
using MyFinancesTracker.ReferenceArchitecture.Domain.Entities;

namespace MyFinancesTracker.ReferenceArchitecture.Domain.Abstractions.Repositories;

public interface IBankTransactionRepository : IRepository<BankTransaction> { }
