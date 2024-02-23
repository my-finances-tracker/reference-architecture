using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFinancesTracker.Transactions.Constants;

namespace MyFinancesTracker.Transactions.DbModel;

[Table(nameof(Transaction), Schema = DatabaseConstants.Schema)]
public abstract class Transaction
{
    public required Guid Id { get; set; }
    public required double Amount { get; set; }
    public required string Source { get; set; } // TODO: maybe this should come from a different source.
    public required TransactionType TransactionType { get; set; }
}
