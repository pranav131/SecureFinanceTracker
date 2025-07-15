using MediatR;
using SecureFinanceTracker.Application.Budgets.DTOs;
using SecureFinanceTracker.Application.Common.Interfaces;
using SecureFinanceTracker.Domain.Entities;

namespace SecureFinanceTracker.Application.Budgets.Commands.CreateBudget;

public class CreateBudgetCommandHandler : IRequestHandler<CreateBudgetCommand, BudgetDto>
{
    private readonly IBudgetRepository _repository;

    public CreateBudgetCommandHandler(IBudgetRepository repository)
    {
        _repository = repository;
    }

    public async Task<BudgetDto> Handle(CreateBudgetCommand request, CancellationToken cancellationToken)
    {
        var budget = new Budget
        {
            Id = Guid.NewGuid(),
            Amount = request.Amount,
            Type = request.Type,
            Month = request.Month,
            Year = request.Year,
            CategoryId = request.CategoryId,
            UserId = request.UserId
        };

        await _repository.AddAsync(budget);

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
