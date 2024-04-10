using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MyFinancesTracker.Common.Crosscutting.Abstractions.Messaging;
using MyFinancesTracker.Transactions.Contracts.V1.Transactions.Dto;

namespace MyFinancesTracker.Transactions.Contracts.V1.Transactions.Commands;
public sealed record CreateBankTransactionCommand : ICommand<CreateBankTransactionResponseDto>
{
    [Required]
    [JsonPropertyName("transaction")]
    public required CreateBankTransactionRequestDto Transaction { get; set; }
}
