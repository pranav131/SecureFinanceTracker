using MediatR;
using SecureFinanceTracker.Application.Categories.DTOs;

namespace SecureFinanceTracker.Application.Categories.Commands.CreateCategory;

public record CreateCategoryCommand(string Name, string Type, Guid UserId) : IRequest<CategoryDto>;
