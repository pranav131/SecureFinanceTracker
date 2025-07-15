using MediatR;
using SecureFinanceTracker.Application.Budgets.DTOs;
using SecureFinanceTracker.Application.Common.Interfaces;

namespace SecureFinanceTracker.Application.Budgets.Queries.GetBudgetById;

public class GetBudgetByIdQueryHandler : IRequestHandler<GetBudgetByIdQuery, BudgetDto>
{
    private readonly IBudgetRepository _repository;

    public GetBudgetByIdQueryHandler(IBudgetRepository repository)
    {
        _repository = repository;
    }

    public async Task<BudgetDto> Handle(GetBudgetByIdQuery request, CancellationToken cancellationToken)
    {
        var budget = await _repository.GetByIdAsync(request.Id)
            ?? throw new Exception("Budget not found.");

        if (budget.UserId != request.UserId)
            throw new UnauthorizedAccessException("Access denied.");

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
