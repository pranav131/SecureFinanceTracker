using MediatR;
using SecureFinanceTracker.Application.Budgets.DTOs;

namespace SecureFinanceTracker.Application.Budgets.Commands.UpdateBudget;

public record UpdateBudgetCommand(
    Guid Id,
    decimal Amount,
    string Type,
    int Month,
    int Year,
    Guid? CategoryId,
    Guid UserId
) : IRequest<BudgetDto>;
