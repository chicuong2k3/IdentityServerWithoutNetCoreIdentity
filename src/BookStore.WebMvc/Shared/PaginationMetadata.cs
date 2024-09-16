namespace BookStore.WebMvc.Shared
{
    public sealed record PaginationMetadata(
        int CurrentPage,
        int PageSize,
        int TotalCount,
        int TotalPages
    );
}