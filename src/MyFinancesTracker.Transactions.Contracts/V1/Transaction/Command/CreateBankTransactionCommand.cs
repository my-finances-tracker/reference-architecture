using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MediatR;
using MyFinancesTracker.Transactions.Contracts.V1.Transaction.Dto;

namespace MyFinancesTracker.Transactions.Contracts.V1.Transaction.Command;
public record CreateBankTransactionCommand : IRequest<CreateBankTransactionResponseDto>
{
    [Required]
    [JsonPropertyName("transaction")]
    public required CreateBankTransactionRequestDto Transaction { get; set; }
}
