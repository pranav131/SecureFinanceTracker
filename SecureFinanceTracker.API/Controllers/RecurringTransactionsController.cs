using MediatR;
using Microsoft.AspNetCore.Mvc;
using SecureFinanceTracker.Application.RecurringTransactions.Commands.CreateRecurringTransaction;
using SecureFinanceTracker.Application.RecurringTransactions.Commands.DeleteRecurringTransaction;
using SecureFinanceTracker.Application.RecurringTransactions.Commands.UpdateRecurringTransaction;
using SecureFinanceTracker.Application.RecurringTransactions.Queries.GetRecurringTransactionById;
using SecureFinanceTracker.Application.RecurringTransactions.Queries.GetAllRecurringTransactions;
using SecureFinanceTracker.Application.RecurringTransactions.DTOs;
using SecureFinanceTracker.Application.RecurringTransactions.Queries;

namespace SecureFinanceTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecurringTransactionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public RecurringTransactionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRecurringTransactionCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RecurringTransactionDto>> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetRecurringTransactionByIdQuery(id));
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<List<RecurringTransactionDto>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllRecurringTransactionsQuery());
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateRecurringTransactionCommand command)
    {
        if (id != command.Id) return BadRequest("ID mismatch.");

        var result = await _mediator.Send(command);
        return result ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteRecurringTransactionCommand(id));
        return result ? NoContent() : NotFound();
    }
}
