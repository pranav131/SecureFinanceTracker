namespace SecureFinanceTracker.Domain.Entities;

public class Transaction
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Category { get; set; } = string.Empty;
    public string? Description { get; set; }
}
