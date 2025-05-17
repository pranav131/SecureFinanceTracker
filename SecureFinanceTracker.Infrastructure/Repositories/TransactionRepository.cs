using SecureFinanceTracker.Domain.Entities;
using SecureFinanceTracker.Domain.Interfaces;
using SecureFinanceTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace SecureFinanceTracker.Infrastructure.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly AppDbContext _dbContext;

    public TransactionRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Transaction transaction)
    {
        _dbContext.Transactions.Add(transaction);
        await _dbContext.SaveChangesAsync();
    }
}
