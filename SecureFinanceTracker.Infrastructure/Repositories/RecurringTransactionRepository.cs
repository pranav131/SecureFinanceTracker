using Microsoft.EntityFrameworkCore;
using SecureFinanceTracker.Application.Common.Interfaces;
using SecureFinanceTracker.Domain.Entities;
using SecureFinanceTracker.Infrastructure.Persistence;

namespace SecureFinanceTracker.Infrastructure.Repositories;

public class RecurringTransactionRepository : IRecurringTransactionRepository
{
    private readonly AppDbContext _context;

    public RecurringTransactionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<RecurringTransaction> CreateAsync(RecurringTransaction transaction)
    {
        _context.RecurringTransactions.Add(transaction);
        await _context.SaveChangesAsync();
        return transaction;
    }

    public async Task<List<RecurringTransaction>> GetAllAsync()
    {
        return await _context.RecurringTransactions.ToListAsync();
    }

    public async Task<RecurringTransaction?> GetByIdAsync(Guid id)
    {
        return await _context.RecurringTransactions.FindAsync(id);
    }

    public async Task<bool> UpdateAsync(RecurringTransaction transaction)
    {
        _context.RecurringTransactions.Update(transaction);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existing = await _context.RecurringTransactions.FindAsync(id);
        if (existing == null) return false;

        _context.RecurringTransactions.Remove(existing);
        return await _context.SaveChangesAsync() > 0;
    }
}
