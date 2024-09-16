using Dapper;

namespace BookStore.Application.Users.GetUserAddresses;

internal sealed class GetUserAddressesQueryHandler(
    IDbConnectionFactory dbConnectionFactory)
    : IQueryHandler<GetUserAddressesQuery, List<UserAddress>>
{
    public async Task<Result<List<UserAddress>>> Handle(GetUserAddressesQuery query, CancellationToken cancellationToken)
    {
        await using (var connection = await dbConnectionFactory.OpenConnectionAsync())
        {
            const string Sql =
               $"""
                SELECT
                    ua.id AS {nameof(UserAddress.AddressId)},
                    ua.address_town AS {nameof(UserAddress.Town)},
                    ua.address_district AS {nameof(UserAddress.District)},
                    ua.address_city AS {nameof(UserAddress.City)},
                    ua.address_address_line AS {nameof(UserAddress.AddressLine)}
                FROM books.users u
                JOIN books.user_addresses ua ON ua.user_id = u.id
                WHERE u.id = @UserId
                """;

            var addresses = (await connection.QueryAsync<UserAddress>(Sql, query)).AsList();

            return Result.Success(addresses);   
        }
    }
}