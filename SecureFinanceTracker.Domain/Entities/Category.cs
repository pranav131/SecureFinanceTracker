namespace SecureFinanceTracker.Domain.Entities;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = "Expense"; // or "Income"
    public Guid UserId { get; set; }  // to associate category with a specific user
}
