using MediatR;
using SecureFinanceTracker.Application.Common.Interfaces;

namespace SecureFinanceTracker.Application.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly ICategoryRepository _repository;

    public DeleteCategoryCommandHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _repository.GetByIdAsync(request.Id)
            ?? throw new Exception("Category not found");

        if (category.UserId != request.UserId)
            throw new UnauthorizedAccessException("Not allowed to delete this category");

        await _repository.DeleteAsync(category);
        return Unit.Value;
    }
}
