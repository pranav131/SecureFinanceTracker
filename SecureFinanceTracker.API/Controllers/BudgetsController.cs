using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureFinanceTracker.Application.Budgets.Commands.CreateBudget;
using SecureFinanceTracker.Application.Budgets.Commands.DeleteBudget;
using SecureFinanceTracker.Application.Budgets.Commands.UpdateBudget;
using SecureFinanceTracker.Application.Budgets.DTOs;
using SecureFinanceTracker.Application.Budgets.Queries.GetBudgets;
using SecureFinanceTracker.Application.Budgets.Queries.GetBudgetById;
using System.Security.Claims;

namespace SecureFinanceTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class BudgetsController : ControllerBase
{
    private readonly IMediator _mediator;

    public BudgetsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private Guid GetUserId()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return Guid.TryParse(userId, out var id) ? id : throw new UnauthorizedAccessException("Invalid user ID in token.");
    }

    [HttpGet]
    public async Task<ActionResult<List<BudgetDto>>> GetBudgets()
    {
        var result = await _mediator.Send(new GetBudgetsQuery(GetUserId()));
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BudgetDto>> GetBudgetById(Guid id)
    {
        var result = await _mediator.Send(new GetBudgetByIdQuery(id, GetUserId()));
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<BudgetDto>> Create([FromBody] CreateBudgetCommand command)
    {
        var result = await _mediator.Send(command with { UserId = GetUserId() });
        return CreatedAtAction(nameof(GetBudgetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<BudgetDto>> Update(Guid id, [FromBody] UpdateBudgetCommand command)
    {
        if (id != command.Id)
            return BadRequest("Mismatched budget ID.");

        var result = await _mediator.Send(command with { UserId = GetUserId() });
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteBudgetCommand(id, GetUserId()));
        return NoContent();
    }
}
