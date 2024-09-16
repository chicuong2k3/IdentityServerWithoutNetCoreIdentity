using BookStore.Domain.Books;

namespace BookStore.Application.Books.CreateBook;
internal sealed class CreateBookCommandHandler(IBookRepository bookRepository)
    : ICommandHandler<CreateBookCommand, CreateBookResponse>
{
    public async Task<Result<CreateBookResponse>> Handle(CreateBookCommand command, CancellationToken cancellationToken)
    {
        
        Result<Book> result = Book.Create(
            command.Title,
            command.Description,
            command.Isbn,
            command.Author,
            command.Price,
            command.Quantity,
            command.CategoryId
        );

        if (result.IsFailure)
        {
            return Result.Failure<CreateBookResponse>(result.Error);
        }

        await bookRepository.InsertAsync(result.Value, cancellationToken);

        return new CreateBookResponse(
                                    result.Value.Id, 
                                    result.Value.Title,
                                    result.Value.Description,
                                    result.Value.Isbn,
                                    result.Value.Author,
                                    result.Value.Price,
                                    result.Value.Quantity,
                                    result.Value.CategoryId
                                );
    }

}
