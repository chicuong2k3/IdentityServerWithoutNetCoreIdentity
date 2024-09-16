using BookStore.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApi.Extensions
{
    public static class DatabaseExtensions
    {
        public static void ApplyMigrations(this IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                ApplyMigration<AppDbContext>(scope);
            }
        }

        internal static void ApplyMigration<TDbContext>(IServiceScope scope)
            where TDbContext : DbContext
        {
            using (var context = scope.ServiceProvider.GetRequiredService<TDbContext>())
            {
                context.Database.EnsureDeleted();
                context.Database.Migrate();
            }
        }
    }
}
