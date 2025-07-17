using MediatR;

namespace SecureFinanceTracker.Application.RecurringTransactions.Commands.DeleteRecurringTransaction;

public record DeleteRecurringTransactionCommand(Guid Id) : IRequest<bool>;
