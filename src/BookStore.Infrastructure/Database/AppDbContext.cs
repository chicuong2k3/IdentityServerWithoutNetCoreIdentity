using System.Reflection;
using Bogus;
using BookStore.Domain.Books;
using BookStore.Domain.Orders;
using BookStore.Infrastructure.Outbox;

namespace BookStore.Infrastructure.Database;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options)
    : DbContext(options)
{
    internal DbSet<Book> Books { get; set; }
    internal DbSet<Category> Categories { get; set; }
    //internal DbSet<User> Users { get; set; }
    //internal DbSet<UserAddress> UserAddresses { get; set; }
    //internal DbSet<Role> Roles { get; set; }
    //internal DbSet<Permission> Permissions { get; set; }
    internal DbSet<Order> Orders { get; set; }
    internal DbSet<OrderItem> OrderItems { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Books);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        Faker faker = new Faker();
        var books = new List<Book>();
        for (int i = 0; i < 100; i++)
        {
            books.Add(Book.Create(
                faker.Commerce.ProductName(),
                faker.Commerce.ProductDescription(),
                faker.Finance.CreditCardNumber(),
                faker.Person.FullName,
                faker.Random.Decimal(10000, 500000),
                faker.Random.Int(1, 100),
                faker.Random.Int(1, 100)
            ));
        }

        modelBuilder.Entity<Book>().HasData(books);
    }

}
