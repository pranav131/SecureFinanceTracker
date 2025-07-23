using MediatR;
using SecureFinanceTracker.Application.Common.Interfaces;
using SecureFinanceTracker.Application.Reports.DTOs;
using SecureFinanceTracker.Application.Reports.Queries.GetMonthlyReport;

public class GetMonthlyReportQueryHandler : IRequestHandler<GetMonthlyReportQuery, MonthlyReportDto>
{
    private readonly IReportRepository _reportRepository;

    public GetMonthlyReportQueryHandler(IReportRepository reportRepository)
    {
        _reportRepository = reportRepository;
    }

    public async Task<MonthlyReportDto> Handle(GetMonthlyReportQuery request, CancellationToken cancellationToken)
    {
        return await _reportRepository.GetMonthlyReportAsync(request.Year, request.Month, cancellationToken);
    }
}
