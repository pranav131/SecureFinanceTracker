namespace SecureFinanceTracker.Domain.Entities;

public class RecurringTransaction
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public decimal Amount { get; set; }
    public string Frequency { get; set; } = null!; // e.g., "Daily", "Weekly", "Monthly"
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Type { get; set; } = null!; // "Income" or "Expense"
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
