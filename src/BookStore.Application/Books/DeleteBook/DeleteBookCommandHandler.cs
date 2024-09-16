using BookStore.Domain.Books;

namespace BookStore.Application.Books.DeleteBook;
internal sealed class DeleteBookCommandHandler(
    IBookRepository bookRepository)
    : ICommandHandler<DeleteBookCommand>
{
    public async Task<Result> Handle(DeleteBookCommand command, CancellationToken cancellationToken)
    {
        var book = await bookRepository.GetAsync(command.BookId);


        if (book is null)
        {
            return Result.Failure(BookErrors.NotFound(command.BookId));
        }

        await bookRepository.DeleteAsync(book, cancellationToken);

        return Result.Success();
    }

}
