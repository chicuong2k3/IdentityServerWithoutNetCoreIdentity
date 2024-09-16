namespace BookStore.Application.Books.SearchBook;

public sealed record BookDto(
    Guid BookId,
    string Title,
    string Author,
    decimal Price,
    int Quantity);
