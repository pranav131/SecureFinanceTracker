using SecureFinanceTracker.Domain.Entities;

namespace SecureFinanceTracker.Domain.Interfaces;

public interface ITransactionRepository
{
    Task AddAsync(Transaction transaction);
    // We can later add: GetByIdAsync, ListAsync, DeleteAsync, etc.
}
