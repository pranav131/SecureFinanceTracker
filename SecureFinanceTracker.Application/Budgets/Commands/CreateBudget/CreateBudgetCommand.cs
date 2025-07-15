using MediatR;
using SecureFinanceTracker.Application.Budgets.DTOs;

namespace SecureFinanceTracker.Application.Budgets.Commands.CreateBudget;

public record CreateBudgetCommand(
    decimal Amount,
    string Type,
    int Month,
    int Year,
    Guid? CategoryId,
    Guid UserId
) : IRequest<BudgetDto>;
