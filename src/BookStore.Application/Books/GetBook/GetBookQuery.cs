namespace BookStore.Application.Books.GetBook;

public sealed record GetBookQuery(Guid BookId) : IQuery<GetBookResponse>;
