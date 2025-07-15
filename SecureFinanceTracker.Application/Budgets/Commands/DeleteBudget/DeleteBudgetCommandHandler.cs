using MediatR;
using SecureFinanceTracker.Application.Common.Interfaces;

namespace SecureFinanceTracker.Application.Budgets.Commands.DeleteBudget;

public class DeleteBudgetCommandHandler : IRequestHandler<DeleteBudgetCommand>
{
    private readonly IBudgetRepository _repository;

    public DeleteBudgetCommandHandler(IBudgetRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteBudgetCommand request, CancellationToken cancellationToken)
    {
        var budget = await _repository.GetByIdAsync(request.Id)
            ?? throw new Exception("Budget not found.");

        if (budget.UserId != request.UserId)
            throw new UnauthorizedAccessException("Access denied.");

        await _repository.DeleteAsync(budget);
        return Unit.Value;
    }
}
