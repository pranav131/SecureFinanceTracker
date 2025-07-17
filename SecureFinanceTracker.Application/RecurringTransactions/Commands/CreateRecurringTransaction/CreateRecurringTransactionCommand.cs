using MediatR;
using SecureFinanceTracker.Application.RecurringTransactions.DTOs;

namespace SecureFinanceTracker.Application.RecurringTransactions.Commands.CreateRecurringTransaction;

public record CreateRecurringTransactionCommand(
    string Title,
    decimal Amount,
    string Frequency,
    DateTime StartDate,
    DateTime? EndDate,
    string Type,
    string? Notes
) : IRequest<RecurringTransactionDto>;
