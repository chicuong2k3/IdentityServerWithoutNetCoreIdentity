using BookStore.Application.Abstractions.Messaging;

namespace BookStore.Application.Books.DeleteBook;

public sealed record DeleteBookCommand(
    Guid BookId
) : ICommand;
