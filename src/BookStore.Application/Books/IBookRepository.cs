
using BookStore.Domain.Books;

namespace BookStore.Application.Books
{
    public interface IBookRepository
    {
        Task<Book?> GetAsync(Guid id);
        Task InsertAsync(Book book, CancellationToken cancellationToken = default);
        Task UpdateAsync(Book book, CancellationToken cancellationToken = default);
        Task DeleteAsync(Book book, CancellationToken cancellationToken = default);
    }
}
