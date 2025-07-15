using MediatR;
using SecureFinanceTracker.Application.Budgets.DTOs;

namespace SecureFinanceTracker.Application.Budgets.Queries.GetBudgetById;

public record GetBudgetByIdQuery(Guid Id, Guid UserId) : IRequest<BudgetDto>;
