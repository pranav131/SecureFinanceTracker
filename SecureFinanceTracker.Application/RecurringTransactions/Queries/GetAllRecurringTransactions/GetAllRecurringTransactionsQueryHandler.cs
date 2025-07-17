using MediatR;
using SecureFinanceTracker.Application.Common.Interfaces;
using SecureFinanceTracker.Application.RecurringTransactions.DTOs;

namespace SecureFinanceTracker.Application.RecurringTransactions.Queries.GetAllRecurringTransactions;

public class GetAllRecurringTransactionsQueryHandler 
    : IRequestHandler<GetAllRecurringTransactionsQuery, List<RecurringTransactionDto>>
{
    private readonly IRecurringTransactionRepository _repository;

    public GetAllRecurringTransactionsQueryHandler(IRecurringTransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<RecurringTransactionDto>> Handle(GetAllRecurringTransactionsQuery request, CancellationToken cancellationToken)
    {
        var transactions = await _repository.GetAllAsync();

        return transactions.Select(t => new RecurringTransactionDto
        {
            Id = t.Id,
            Title = t.Title,
            Amount = t.Amount,
            Frequency = t.Frequency,
            StartDate = t.StartDate,
            EndDate = t.EndDate,
            Type = t.Type,
            Notes = t.Notes
        }).ToList();
    }
}
