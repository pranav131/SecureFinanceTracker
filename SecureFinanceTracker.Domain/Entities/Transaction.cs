namespace SecureFinanceTracker.Domain.Entities;

public class Transaction
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }

    public Guid CategoryId { get; set; }   // FK
    public Category Category { get; set; } = null!;  // Navigation

    public string? Description { get; set; }
}