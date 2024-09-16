using Refit;
namespace BookStore.WebMvc.Books
{
    public interface IBooksClient
    {
        [Get("/books")]
        Task<ApiResponse<IEnumerable<GetBooksModel>>> GetBooksAsync(
            int pageNumber,
            int pageSize,
            string queryText);

        [Post("/books")]
        Task<ApiResponse<GetBookModel>> CreateBookAsync([Body] CreateBookModel book);
    }
}
