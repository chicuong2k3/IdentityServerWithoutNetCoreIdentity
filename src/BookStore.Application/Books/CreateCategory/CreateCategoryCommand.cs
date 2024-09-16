
namespace BookStore.Application.Books.CreateCategory;

public sealed record CreateCategoryCommand(
    string Name
) : ICommand<int>;
