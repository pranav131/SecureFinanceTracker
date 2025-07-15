using MediatR;
using SecureFinanceTracker.Application.Budgets.DTOs;
using SecureFinanceTracker.Application.Common.Interfaces;

namespace SecureFinanceTracker.Application.Budgets.Commands.UpdateBudget;

public class UpdateBudgetCommandHandler : IRequestHandler<UpdateBudgetCommand, BudgetDto>
{
    private readonly IBudgetRepository _repository;

    public UpdateBudgetCommandHandler(IBudgetRepository repository)
    {
        _repository = repository;
    }

    public async Task<BudgetDto> Handle(UpdateBudgetCommand request, CancellationToken cancellationToken)
    {
        var budget = await _repository.GetByIdAsync(request.Id)
            ?? throw new Exception("Budget not found.");

        if (budget.UserId != request.UserId)
            throw new UnauthorizedAccessException("Access denied.");

        budget.Amount = request.Amount;
        budget.Type = request.Type;
        budget.Month = request.Month;
        budget.Year = request.Year;
        budget.CategoryId = request.CategoryId;

        await _repository.UpdateAsync(budget);

        return new BudgetDto
        {
            Id = budget.Id,
            Amount = budget.Amount,
            Type = budget.Type,
            Month = budget.Month,
            Year = budget.Year,
            CategoryId = budget.CategoryId
        };
    }
}
