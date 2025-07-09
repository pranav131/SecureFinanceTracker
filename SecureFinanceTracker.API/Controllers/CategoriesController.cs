using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureFinanceTracker.Application.Categories.Commands.CreateCategory;
using SecureFinanceTracker.Application.Categories.Commands.DeleteCategory;
using SecureFinanceTracker.Application.Categories.Commands.UpdateCategory;
using SecureFinanceTracker.Application.Categories.DTOs;
using SecureFinanceTracker.Application.Categories.Queries.GetCategories;
using SecureFinanceTracker.Application.Categories.Queries.GetCategoryById;
using System.Security.Claims;

namespace SecureFinanceTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // Helper to get UserId from JWT
    private Guid GetUserId()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return Guid.TryParse(userId, out var id) ? id : throw new UnauthorizedAccessException("Invalid user ID in token.");
    }

    [HttpGet]
    public async Task<ActionResult<List<CategoryDto>>> GetCategories()
    {
        var result = await _mediator.Send(new GetCategoriesQuery(GetUserId()));
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDto>> GetCategoryById(Guid id)
    {
        var result = await _mediator.Send(new GetCategoryByIdQuery(id, GetUserId()));
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<CategoryDto>> Create([FromBody] CreateCategoryCommand command)
    {
        var userId = GetUserId();
        var result = await _mediator.Send(command with { UserId = userId });
        return CreatedAtAction(nameof(GetCategoryById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CategoryDto>> Update(Guid id, [FromBody] UpdateCategoryCommand command)
    {
        if (id != command.Id)
            return BadRequest("Mismatched category ID.");

        var result = await _mediator.Send(command with { UserId = GetUserId() });
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteCategoryCommand(id, GetUserId()));
        return NoContent();
    }
}
