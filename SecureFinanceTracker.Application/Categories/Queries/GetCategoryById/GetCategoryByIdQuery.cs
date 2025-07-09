using MediatR;
using SecureFinanceTracker.Application.Categories.DTOs;

namespace SecureFinanceTracker.Application.Categories.Queries.GetCategoryById;

public record GetCategoryByIdQuery(Guid Id, Guid UserId) : IRequest<CategoryDto>;
