using System.Data.Common;

namespace BookStore.Application.Abstractions.Database
{
    public interface IDbConnectionFactory
    {
        ValueTask<DbConnection> OpenConnectionAsync();
    }
}
