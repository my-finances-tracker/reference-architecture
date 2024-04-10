using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyFinancesTracker.Transactions.Contracts.V1.Transactions.Dto;
public record CreateBankTransactionResponseDto
{
    [Required]
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
}
