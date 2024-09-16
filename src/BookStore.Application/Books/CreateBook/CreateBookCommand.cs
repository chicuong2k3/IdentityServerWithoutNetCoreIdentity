using BookStore.Application.Abstractions.Messaging;

namespace BookStore.Application.Books.CreateBook;

public sealed record CreateBookCommand(
    string Title,
    string Description,
    string Isbn,
    string Author,
    decimal Price,
    int Quantity,
    int CategoryId
) : ICommand<CreateBookResponse>;
