using MediatR;
using System;

namespace SecureFinanceTracker.Application.Transactions.Commands.CreateTransaction;

public class CreateTransactionCommand : IRequest<Guid> // Return transaction ID
{
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public Guid CategoryId { get; set; }
    public string? Description { get; set; }
}
