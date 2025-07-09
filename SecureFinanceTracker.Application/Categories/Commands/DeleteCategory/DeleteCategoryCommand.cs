using MediatR;

namespace SecureFinanceTracker.Application.Categories.Commands.DeleteCategory;

public record DeleteCategoryCommand(Guid Id, Guid UserId) : IRequest;
