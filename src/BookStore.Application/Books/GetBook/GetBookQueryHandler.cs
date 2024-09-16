using BookStore.Domain.Books;
using Dapper;

namespace BookStore.Application.Books.GetBook;
internal sealed class GetBookQueryHandler(
    IDbConnectionFactory dbConnectionFactory)
    : IQueryHandler<GetBookQuery, GetBookResponse>
{
    public async Task<Result<GetBookResponse>> Handle(GetBookQuery query, CancellationToken cancellationToken)
    {
        await using var dbConnection = await dbConnectionFactory.OpenConnectionAsync();

        string sql =
            $"""
            SELECT 
                id AS {nameof(GetBookResponse.BookId)},
                title AS {nameof(GetBookResponse.Title)},
                description AS {nameof(GetBookResponse.Description)},
                author AS {nameof(GetBookResponse.Author)},
                price AS {nameof(GetBookResponse.Price)},
                quantity AS {nameof(GetBookResponse.Quantity)}
            FROM books.books
            WHERE id = @BookId
            """;

        var book = await dbConnection.QuerySingleOrDefaultAsync<GetBookResponse>(sql, query);

        if (book is null)
        {
            return Result.Failure<GetBookResponse>(BookErrors.NotFound(query.BookId));
        }

        return book;
    }
}
