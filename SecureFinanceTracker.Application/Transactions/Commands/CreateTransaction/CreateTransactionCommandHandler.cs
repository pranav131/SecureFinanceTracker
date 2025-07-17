using MediatR;
using SecureFinanceTracker.Application.Common.Exceptions;
using SecureFinanceTracker.Application.Common.Interfaces;
using SecureFinanceTracker.Domain.Entities;
using SecureFinanceTracker.Domain.Interfaces;

namespace SecureFinanceTracker.Application.Transactions.Commands.CreateTransaction;

public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Guid>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly ICategoryRepository _categoryRepository;

    public CreateTransactionCommandHandler(ITransactionRepository transactionRepository, ICategoryRepository categoryRepository)
    {
        _transactionRepository = transactionRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<Guid> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
        if (category is null)
            throw new NotFoundException("Category not found");
        var transaction = new Transaction
        {
            Id = Guid.NewGuid(),
            Amount = request.Amount,
            Date = request.Date,
            CategoryId = request.CategoryId,
            Description = request.Description
        };

        await _transactionRepository.AddAsync(transaction);

        return transaction.Id;
    }
}
