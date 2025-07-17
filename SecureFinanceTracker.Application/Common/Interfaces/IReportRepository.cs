using SecureFinanceTracker.Application.Reports.DTOs;

namespace SecureFinanceTracker.Application.Common.Interfaces;

public interface IReportRepository
{
    Task<MonthlyReportDto> GetMonthlyReportAsync(int year, int month, CancellationToken cancellationToken);
}
