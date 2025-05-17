using MediatR;
using SecureFinanceTracker.Domain.Entities;
using SecureFinanceTracker.Domain.Interfaces;

namespace SecureFinanceTracker.Application.Transactions.Commands.CreateTransaction;

public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Guid>
{
    private readonly ITransactionRepository _transactionRepository;

    public CreateTransactionCommandHandler(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<Guid> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        var transaction = new Transaction
        {
            Id = Guid.NewGuid(),
            Amount = request.Amount,
            Date = request.Date,
            Category = request.Category,
            Description = request.Description
        };

        await _transactionRepository.AddAsync(transaction);

        return transaction.Id;
    }
}
