using MediatR;
using SecureFinanceTracker.Application.Categories.DTOs;

namespace SecureFinanceTracker.Application.Categories.Queries.GetCategories;

public record GetCategoriesQuery(Guid UserId) : IRequest<List<CategoryDto>>;
