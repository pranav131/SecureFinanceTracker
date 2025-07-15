using MediatR;
using SecureFinanceTracker.Application.Budgets.DTOs;

namespace SecureFinanceTracker.Application.Budgets.Queries.GetBudgets;

public record GetBudgetsQuery(Guid UserId) : IRequest<List<BudgetDto>>;
