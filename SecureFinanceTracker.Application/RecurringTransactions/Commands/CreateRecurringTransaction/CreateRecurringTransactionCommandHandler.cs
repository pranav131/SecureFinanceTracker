using MediatR;
using SecureFinanceTracker.Application.Common.Interfaces;
using SecureFinanceTracker.Application.RecurringTransactions.DTOs;
using SecureFinanceTracker.Domain.Entities;

namespace SecureFinanceTracker.Application.RecurringTransactions.Commands.CreateRecurringTransaction;

public class CreateRecurringTransactionCommandHandler 
    : IRequestHandler<CreateRecurringTransactionCommand, RecurringTransactionDto>
{
    private readonly IRecurringTransactionRepository _repository;

    public CreateRecurringTransactionCommandHandler(IRecurringTransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task<RecurringTransactionDto> Handle(
        CreateRecurringTransactionCommand request,
        CancellationToken cancellationToken)
    {
        var transaction = new RecurringTransaction
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Amount = request.Amount,
            Frequency = request.Frequency,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            Type = request.Type,
            Notes = request.Notes
        };

        var createdTransaction = await _repository.CreateAsync(transaction);

        return new RecurringTransactionDto
        {
            Id = createdTransaction.Id,
            Title = createdTransaction.Title,
            Amount = createdTransaction.Amount,
            Frequency = createdTransaction.Frequency,
            StartDate = createdTransaction.StartDate,
            EndDate = createdTransaction.EndDate,
            Type = createdTransaction.Type,
            Notes = createdTransaction.Notes
        };
    }
}
