using MediatR;
using SecureFinanceTracker.Application.RecurringTransactions.DTOs;

namespace SecureFinanceTracker.Application.RecurringTransactions.Commands.UpdateRecurringTransaction;

public record UpdateRecurringTransactionCommand : IRequest<bool>
{
    public Guid Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public decimal Amount { get; init; }
    public string Frequency { get; init; } = string.Empty;
    public DateTime StartDate { get; init; }
    public DateTime? EndDate { get; init; }
    public string Type { get; init; } = string.Empty;
    public string? Notes { get; init; }
}
