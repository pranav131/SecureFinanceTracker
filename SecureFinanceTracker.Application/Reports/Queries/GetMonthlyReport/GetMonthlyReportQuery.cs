using MediatR;
using SecureFinanceTracker.Application.Reports.DTOs;

namespace SecureFinanceTracker.Application.Reports.Queries.GetMonthlyReport;

public record GetMonthlyReportQuery(int Year, int Month) : IRequest<MonthlyReportDto>;
