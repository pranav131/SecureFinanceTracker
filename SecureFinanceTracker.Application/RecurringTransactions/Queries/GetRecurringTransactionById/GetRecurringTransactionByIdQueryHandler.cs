using MediatR;
using SecureFinanceTracker.Application.Common.Interfaces;
using SecureFinanceTracker.Application.RecurringTransactions.DTOs;

namespace SecureFinanceTracker.Application.RecurringTransactions.Queries.GetRecurringTransactionById;

public class GetRecurringTransactionByIdQueryHandler 
    : IRequestHandler<GetRecurringTransactionByIdQuery, RecurringTransactionDto>
{
    private readonly IRecurringTransactionRepository _repository;

    public GetRecurringTransactionByIdQueryHandler(IRecurringTransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task<RecurringTransactionDto> Handle(GetRecurringTransactionByIdQuery request, CancellationToken cancellationToken)
    {
        var transaction = await _repository.GetByIdAsync(request.Id);

        if (transaction == null)
            return null!;

        return new RecurringTransactionDto
        {
            Id = transaction.Id,
            Title = transaction.Title,
            Amount = transaction.Amount,
            Frequency = transaction.Frequency,
            StartDate = transaction.StartDate,
            EndDate = transaction.EndDate,
            Type = transaction.Type,
            Notes = transaction.Notes
        };
    }
}
