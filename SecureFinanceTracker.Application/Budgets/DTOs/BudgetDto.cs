using System;

namespace SecureFinanceTracker.Application.Budgets.DTOs;

public class BudgetDto
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public Guid? CategoryId { get; set; }
    public string Type { get; set; } = "Expense";
    public int Month { get; set; }
    public int Year { get; set; }

}
