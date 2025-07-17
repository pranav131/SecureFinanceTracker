using MediatR;
using SecureFinanceTracker.Application.RecurringTransactions.DTOs;

namespace SecureFinanceTracker.Application.RecurringTransactions.Queries.GetAllRecurringTransactions;

public record GetAllRecurringTransactionsQuery : IRequest<List<RecurringTransactionDto>>;
