namespace BookStore.Domain.Books
{
    public static class CategoryErrors
    {
        public static Error NotFound(int id) => Error.NotFound(
            "Categories.NotFound", $"The category with the identitfy {id} was not found.");
    }
}
