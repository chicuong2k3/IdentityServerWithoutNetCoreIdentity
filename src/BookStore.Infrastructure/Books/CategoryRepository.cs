using BookStore.Application.Books;

namespace CategoryStore.Infrastructure.Categorys
{
    internal class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext context;

        public CategoryRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task InsertAsync(Category category, CancellationToken cancellationToken = default)
        {
            context.Categories.Add(category);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Category category, CancellationToken cancellationToken = default)
        {
            context.Categories.Remove(category);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Category?> GetAsync(int id)
        {
            return await context.Categories.FindAsync(id);
        }

        public async Task UpdateAsync(Category category, CancellationToken cancellationToken = default)
        {
            context.Categories.Update(category);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
