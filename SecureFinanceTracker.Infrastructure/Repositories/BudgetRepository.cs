using Microsoft.EntityFrameworkCore;
using SecureFinanceTracker.Application.Common.Interfaces;
using SecureFinanceTracker.Domain.Entities;
using SecureFinanceTracker.Infrastructure.Persistence;

namespace SecureFinanceTracker.Infrastructure.Repositories;

public class BudgetRepository : IBudgetRepository
{
    private readonly AppDbContext _dbContext;

    public BudgetRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Budget>> GetAllAsync(Guid userId)
    {
        return await _dbContext.Budgets
            .Where(b => b.UserId == userId)
            .ToListAsync();
    }

    public async Task<Budget?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Budgets.FindAsync(id);
    }

    public async Task AddAsync(Budget budget)
    {
        _dbContext.Budgets.Add(budget);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Budget budget)
    {
        _dbContext.Budgets.Update(budget);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Budget budget)
    {
        _dbContext.Budgets.Remove(budget);
        await _dbContext.SaveChangesAsync();
    }
}
