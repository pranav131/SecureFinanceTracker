using MediatR;

namespace SecureFinanceTracker.Application.Budgets.Commands.DeleteBudget;

public record DeleteBudgetCommand(Guid Id, Guid UserId) : IRequest;
