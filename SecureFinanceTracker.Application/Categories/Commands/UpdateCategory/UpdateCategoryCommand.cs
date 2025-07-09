using MediatR;
using SecureFinanceTracker.Application.Categories.DTOs;

namespace SecureFinanceTracker.Application.Categories.Commands.UpdateCategory;

public record UpdateCategoryCommand(Guid Id, string Name, string Type, Guid UserId) : IRequest<CategoryDto>;
