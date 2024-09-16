namespace BookStore.Domain.Books
{
    public static class BookErrors
    {
        public static Error NotFound(Guid id) => Error.NotFound(
            "Books.NotFound", $"The book with the identitfy {id} was not found.");
    }
}
