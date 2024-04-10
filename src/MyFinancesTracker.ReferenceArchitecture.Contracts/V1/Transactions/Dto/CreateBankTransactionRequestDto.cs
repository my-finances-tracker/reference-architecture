using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MyFinancesTracker.Transactions.Contracts.V1.Transactions.Enums;

namespace MyFinancesTracker.Transactions.Contracts.V1.Transactions.Dto;
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
