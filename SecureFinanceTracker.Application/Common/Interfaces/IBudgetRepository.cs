using SecureFinanceTracker.Domain.Entities;

namespace SecureFinanceTracker.Application.Common.Interfaces;

public interface IBudgetRepository
{
    Task<List<Budget>> GetAllAsync(Guid userId);
    Task<Budget?> GetByIdAsync(Guid id);
    Task AddAsync(Budget budget);
    Task UpdateAsync(Budget budget);
    Task DeleteAsync(Budget budget);
}
