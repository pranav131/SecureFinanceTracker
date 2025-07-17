namespace SecureFinanceTracker.Application.RecurringTransactions.DTOs;

public class RecurringTransactionDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public decimal Amount { get; set; }
    public string Frequency { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Type { get; set; } = null!;
    public string? Notes { get; set; }
}
