using MediatR;
using Microsoft.AspNetCore.Mvc;
using SecureFinanceTracker.Application.Transactions.Commands.CreateTransaction;

namespace SecureFinanceTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TransactionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTransaction(CreateTransactionCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, null); // Placeholder for future GetById
    }

    // Optional placeholder method to prevent CreatedAtAction error
    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        return Ok(); // Will implement later
    }
}
