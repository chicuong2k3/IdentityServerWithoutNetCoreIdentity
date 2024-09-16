using BookStore.Application.Shared;

namespace BookStore.Application.Books.SearchBook;

public sealed record SearchBookQuery(
    int PageNumber,    
    int PageSize,
    string? QueryText,
    string? OrderBy
) : IQuery<PagedList<BookDto>>;
