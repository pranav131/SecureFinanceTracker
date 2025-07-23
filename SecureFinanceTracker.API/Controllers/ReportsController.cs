using MediatR;
using Microsoft.AspNetCore.Mvc;
using SecureFinanceTracker.Application.Reports.DTOs;
using SecureFinanceTracker.Application.Reports.Queries.GetMonthlyReport;

namespace SecureFinanceTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get monthly financial report
        /// </summary>
        /// <param name="year">Year (e.g., 2025)</param>
        /// <param name="month">Month (1-12)</param>
        /// <returns>MonthlyReportDto</returns>
        [HttpGet("monthly")]
        public async Task<ActionResult<MonthlyReportDto>> GetMonthlyReport([FromQuery] int year, [FromQuery] int month)
        {
            if (month < 1 || month > 12)
                return BadRequest("Invalid month. Must be between 1 and 12.");

            var query = new GetMonthlyReportQuery(year, month);
            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
