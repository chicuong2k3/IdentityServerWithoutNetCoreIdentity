using BookStore.Application.Books;

namespace BookStore.Infrastructure.Books
{
    internal class BookRepository : IBookRepository
    {
        private readonly AppDbContext context;

        public BookRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task InsertAsync(Book book, CancellationToken cancellationToken = default)
        {
            context.Books.Add(book);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Book book, CancellationToken cancellationToken = default)
        {
            context.Books.Remove(book);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Book?> GetAsync(Guid id)
        {
            return await context.Books.FindAsync(id);
        }

        public async Task UpdateAsync(Book book, CancellationToken cancellationToken = default)
        {
            context.Books.Update(book);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
