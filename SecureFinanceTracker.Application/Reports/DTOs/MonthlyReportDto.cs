namespace SecureFinanceTracker.Application.Reports.DTOs;

public class MonthlyReportDto
{
    public decimal TotalIncome { get; set; }
    public decimal TotalExpenses { get; set; }
    public decimal NetBalance => TotalIncome - TotalExpenses;

    public List<CategoryBreakdownDto> CategoryBreakdowns { get; set; } = new();
}
