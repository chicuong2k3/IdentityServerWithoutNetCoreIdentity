namespace BookStore.Application.Books.GetBook;

public sealed record GetBookResponse(
    Guid BookId,
    string Title,
    string Description,
    string Author,
    decimal Price,
    int Quantity
);
