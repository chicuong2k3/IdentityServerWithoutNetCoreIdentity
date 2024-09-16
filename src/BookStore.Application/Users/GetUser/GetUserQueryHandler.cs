using Dapper;

namespace BookStore.Application.Users.GetUser;

internal sealed class GetUserQueryHandler(
    IDbConnectionFactory dbConnectionFactory)
    : IQueryHandler<GetUserQuery, GetUserResponse>
{
    public async Task<Result<GetUserResponse>> Handle(GetUserQuery query, CancellationToken cancellationToken)
    {
        await using (var connection = await dbConnectionFactory.OpenConnectionAsync())
        {
            const string Sql =
               $"""
                SELECT
                    id AS {nameof(GetUserResponse.Id)},
                    email AS {nameof(GetUserResponse.Email)},
                    first_name AS {nameof(GetUserResponse.FirstName)},
                    last_name AS {nameof(GetUserResponse.LastName)}
                FROM books.users
                WHERE id = @Id
                """
            ;

            var user = await connection.QuerySingleOrDefaultAsync<GetUserResponse>(Sql, query);
            if (user is null)
            {
                return Result.Failure<GetUserResponse>(UserErrors.NotFound(query.Id));
            }

            return user;
        }
    }
}