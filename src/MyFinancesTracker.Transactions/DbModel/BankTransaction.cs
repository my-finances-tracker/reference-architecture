using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFinancesTracker.Transactions.Constants;

namespace MyFinancesTracker.Transactions.DbModel;

[Table(nameof(Transaction), Schema = DatabaseConstants.Schema)]
public class BankTransaction : Transaction
{
    public required string Description { get; set; }
    public string? Sender { get; set; }
    public string? Receiver { get; set; }
}
