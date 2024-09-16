using BookStore.Domain.Books;

namespace BookStore.Application.Books.CreateCategory;
internal sealed class CreateCategoryCommandHandler(
    ICategoryRepository categoryRepository)
    : ICommandHandler<CreateCategoryCommand, int>
{
    public async Task<Result<int>> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
    {

        Result<Category> result = Category.Create(command.Name);

        if (result.IsFailure)
        {
            return Result.Failure<int>(result.Error);
        }

        await categoryRepository.InsertAsync(result.Value, cancellationToken);

        return result.Value.Id;
    }

}
