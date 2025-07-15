using MediatR;
using SecureFinanceTracker.Application.Budgets.DTOs;
using SecureFinanceTracker.Application.Common.Interfaces;

namespace SecureFinanceTracker.Application.Budgets.Queries.GetBudgets;

public class GetBudgetsQueryHandler : IRequestHandler<GetBudgetsQuery, List<BudgetDto>>
{
    private readonly IBudgetRepository _repository;

    public GetBudgetsQueryHandler(IBudgetRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<BudgetDto>> Handle(GetBudgetsQuery request, CancellationToken cancellationToken)
    {
        var budgets = await _repository.GetAllAsync(request.UserId);

        return budgets.Select(b => new BudgetDto
        {
            Id = b.Id,
            Amount = b.Amount,
            Type = b.Type,
            Month = b.Month,
            Year = b.Year,
            CategoryId = b.CategoryId
        }).ToList();
    }
}
