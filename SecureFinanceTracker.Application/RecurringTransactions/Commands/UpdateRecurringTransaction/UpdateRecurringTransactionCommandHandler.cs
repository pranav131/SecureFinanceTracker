using MediatR;
using SecureFinanceTracker.Application.Common.Interfaces;
using SecureFinanceTracker.Domain.Entities;

namespace SecureFinanceTracker.Application.RecurringTransactions.Commands.UpdateRecurringTransaction;

public class UpdateRecurringTransactionCommandHandler 
    : IRequestHandler<UpdateRecurringTransactionCommand, bool>
{
    private readonly IRecurringTransactionRepository _repository;

    public UpdateRecurringTransactionCommandHandler(IRecurringTransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateRecurringTransactionCommand request, CancellationToken cancellationToken)
    {
        var existing = await _repository.GetByIdAsync(request.Id);

        if (existing == null)
            return false;

        existing.Title = request.Title;
        existing.Amount = request.Amount;
        existing.Frequency = request.Frequency;
        existing.StartDate = request.StartDate;
        existing.EndDate = request.EndDate;
        existing.Type = request.Type;
        existing.Notes = request.Notes;

        return await _repository.UpdateAsync(existing);
    }
}
