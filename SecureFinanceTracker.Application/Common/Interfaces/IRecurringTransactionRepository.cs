using SecureFinanceTracker.Domain.Entities;

namespace SecureFinanceTracker.Application.Common.Interfaces;

public interface IRecurringTransactionRepository
{
    Task<RecurringTransaction> CreateAsync(RecurringTransaction transaction);
    Task<List<RecurringTransaction>> GetAllAsync();
    Task<RecurringTransaction?> GetByIdAsync(Guid id);
    Task<bool> UpdateAsync(RecurringTransaction transaction);
    Task<bool> DeleteAsync(Guid id);
}
