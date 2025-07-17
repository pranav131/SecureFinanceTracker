using Microsoft.EntityFrameworkCore;
using SecureFinanceTracker.Application.Common.Interfaces;
using SecureFinanceTracker.Application.Reports.DTOs;
using SecureFinanceTracker.Domain.Entities;
using SecureFinanceTracker.Infrastructure.Persistence;

namespace SecureFinanceTracker.Infrastructure.Repositories;

public class ReportRepository : IReportRepository
{
    private readonly AppDbContext _context;

    public ReportRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<MonthlyReportDto> GetMonthlyReportAsync(int year, int month, CancellationToken cancellationToken)
    {
        var startDate = new DateTime(year, month, 1);
        var endDate = startDate.AddMonths(1).AddDays(-1);

        var transactions = await _context.Transactions
            .Include(t => t.Category)
            .Where(t => t.Date >= startDate && t.Date <= endDate)
            .ToListAsync(cancellationToken);

        var income = transactions
            .Where(t => t.Category.Type == "Income")
            .Sum(t => t.Amount);

        var expenses = transactions
            .Where(t => t.Category.Type == "Expense")
            .Sum(t => t.Amount);

        var categoryBreakdowns = transactions
            .GroupBy(t => t.Category?.Name ?? "Uncategorized")
            .Select(g => new CategoryBreakdownDto
            {
                Category = g.Key,
                Amount = g.Sum(t => t.Amount)
            })
            .ToList();

        return new MonthlyReportDto
        {
            TotalIncome = income,
            TotalExpenses = expenses,
            CategoryBreakdowns = categoryBreakdowns
        };
    }
}
