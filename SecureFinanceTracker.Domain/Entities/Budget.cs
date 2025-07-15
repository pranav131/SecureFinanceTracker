using System;

namespace SecureFinanceTracker.Domain.Entities;

public class Budget
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    public Guid? CategoryId { get; set; }  // Optional
    public decimal Amount { get; set; }

    public int Year { get; set; }
    public int Month { get; set; }

    public string Type { get; set; } = "Expense"; // or "Income"
}
