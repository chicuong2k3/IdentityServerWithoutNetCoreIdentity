namespace BookStore.WebApi.Requests.Books;

public sealed record CreateBookRequest(
    string Title,
    string Description,
    string Isbn,
    string Author,
    decimal Price,
    int Quantity,
    int CategoryId
);
