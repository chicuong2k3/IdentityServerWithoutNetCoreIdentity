using BookStore.Domain.Books;

namespace BookStore.Application.Books.UpdateBookPrice;
internal sealed class UpdateBookPriceCommandHandler(
    IBookRepository bookRepository)
    : ICommandHandler<UpdateBookPriceCommand>
{
    public async Task<Result> Handle(UpdateBookPriceCommand command, CancellationToken cancellationToken)
    {
        var book = await bookRepository.GetAsync(command.Id);

        if (book is null)
        {
            return Result.Failure(BookErrors.NotFound(command.Id));
        }

        book.UpdatePrice(command.Price);
        await bookRepository.UpdateAsync(book, cancellationToken);

        return Result.Success();
    }

}
