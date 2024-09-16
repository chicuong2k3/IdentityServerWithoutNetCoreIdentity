using BookStore.Application.Shared;
using Dapper;
using System.Text;

namespace BookStore.Application.Books.SearchBook;
internal sealed class SearchBookQueryHandler(
    IDbConnectionFactory dbConnectionFactory)
    : IQueryHandler<SearchBookQuery, PagedList<BookDto>>
{
    public async Task<Result<PagedList<BookDto>>> Handle(SearchBookQuery query, CancellationToken cancellationToken)
    {
        await using var dbConnection = await dbConnectionFactory.OpenConnectionAsync();

        string countSql = 
            """
            SELECT COUNT(*) 
            FROM books.books 
            WHERE title LIKE @QueryText
            """;

        var count = await dbConnection.ExecuteScalarAsync<int>(countSql, new { QueryText = $"%{query.QueryText}%" });

        var orderByQuery = GetOrderByQuery(query.OrderBy);

        if (orderByQuery is null)
        {
            return Result.Failure<PagedList<BookDto>>(
                    Error.Problem(
                        "Books.InvalidParameters",
                        "Invalid parameters for ordering books"
                    ));
        }

        string sql =
            $"""
            SELECT 
                id AS {nameof(BookDto.BookId)},
                title AS {nameof(BookDto.Title)},
                author AS {nameof(BookDto.Author)},
                price AS {nameof(BookDto.Price)},
                quantity AS {nameof(BookDto.Quantity)}
            FROM books.books
            WHERE title LIKE @QueryText
            {orderByQuery}
            LIMIT @PageSize OFFSET @Offset
            """;

        var parameters = new
        {
            QueryText = $"%{query.QueryText}%",
            PageSize = query.PageSize,
            Offset = (query.PageNumber - 1) * query.PageSize
        };

        var books = (await dbConnection.QueryAsync<BookDto>(sql, parameters)).AsList();

        return new PagedList<BookDto>(books, count, query.PageNumber, query.PageSize);
    }

    private string? GetOrderByQuery(string? orderBy)
    {
        if (string.IsNullOrEmpty(orderBy))
        {
            return string.Empty;
        }

        var orderByQuery = new StringBuilder("ORDER BY ");

        var orderByClauses = orderBy.ToLower().Split(',');

        foreach (var orderByClause in orderByClauses)
        {
            var trimmedOrderByClause = orderByClause.Trim();
            var isDescending = trimmedOrderByClause.EndsWith(" desc", StringComparison.OrdinalIgnoreCase);
            var indexOfSpace = trimmedOrderByClause.IndexOf(' ');
            var propertyName = indexOfSpace < 0 
                    ? trimmedOrderByClause : trimmedOrderByClause[..indexOfSpace];

            var mappingPropertyName = propertyName switch
            {
                "title" => "title",
                "author" => "author",
                "price" => "price",
                "quantity" => "quantity",
                _ => string.Empty
            };

            if (string.IsNullOrEmpty(mappingPropertyName))
            {
                return null;
            }

            orderByQuery.Append($"{mappingPropertyName} {(isDescending ? "DESC" : "ASC")}, ");
        }

        orderByQuery.Length -= 2;

        return orderByQuery.ToString(); 
    }
}
