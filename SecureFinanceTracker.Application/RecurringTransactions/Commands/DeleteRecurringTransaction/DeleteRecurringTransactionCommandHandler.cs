using MediatR;
using SecureFinanceTracker.Application.Common.Interfaces;

namespace SecureFinanceTracker.Application.RecurringTransactions.Commands.DeleteRecurringTransaction;

public class DeleteRecurringTransactionCommandHandler 
    : IRequestHandler<DeleteRecurringTransactionCommand, bool>
{
    private readonly IRecurringTransactionRepository _repository;

    public DeleteRecurringTransactionCommandHandler(IRecurringTransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteRecurringTransactionCommand request, CancellationToken cancellationToken)
    {
        return await _repository.DeleteAsync(request.Id);
    }
}
