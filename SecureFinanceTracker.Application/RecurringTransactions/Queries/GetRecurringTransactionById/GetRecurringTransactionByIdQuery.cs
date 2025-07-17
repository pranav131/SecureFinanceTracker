using MediatR;
using SecureFinanceTracker.Application.RecurringTransactions.DTOs;

namespace SecureFinanceTracker.Application.RecurringTransactions.Queries.GetRecurringTransactionById;

public record GetRecurringTransactionByIdQuery(Guid Id) : IRequest<RecurringTransactionDto>;
