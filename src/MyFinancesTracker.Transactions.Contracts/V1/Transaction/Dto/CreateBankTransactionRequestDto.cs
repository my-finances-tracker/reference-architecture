using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MyFinancesTracker.Transactions.Contracts.V1.Transaction.Enums;

namespace MyFinancesTracker.Transactions.Contracts.V1.Transaction.Dto;
public record CreateBankTransactionRequestDto
{
    [Required]
    [JsonPropertyName("amount")]
    public required double Amount { get; set; }
    [Required]
    [JsonPropertyName("source")]
    public required string Source { get; set; }
    [Required]
    [JsonPropertyName("transactionType")]
    public required TransactionType transactionType { get; set; }
    [Required]
    [JsonPropertyName("description")]
    public required string Description { get; set; }
    
    [JsonPropertyName("sender")]
    public string? Sender { get; set; }
    [JsonPropertyName("receiver")]
    public string? Receiver { get; set; }

}
