
using BookStore.Domain.Books;

namespace BookStore.Application.Books
{
    public interface ICategoryRepository
    {
        Task<Category?> GetAsync(int id);
        Task InsertAsync(Category category, CancellationToken cancellationToken = default);
        Task UpdateAsync(Category category, CancellationToken cancellationToken = default);
        Task DeleteAsync(Category category, CancellationToken cancellationToken = default);
    }
}
