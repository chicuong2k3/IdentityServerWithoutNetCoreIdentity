using BookStore.Application.Abstractions.Database;
using Npgsql;
using System.Data.Common;

namespace BookStore.Infrastructure.Database
{
    internal sealed class DbConnectionFactory(NpgsqlDataSource dataSource)
        : IDbConnectionFactory
    {
        public async ValueTask<DbConnection> OpenConnectionAsync()
        {
            return await dataSource.OpenConnectionAsync();
        }
    }
}
