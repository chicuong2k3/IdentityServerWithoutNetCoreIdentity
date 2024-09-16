namespace BookStore.WebApi.Requests.Books;

public sealed record SearchBookRequest(
    int PageNumber = 1,
    int PageSize = 5,
    string? QueryText = null,
    string? OrderBy = null,
    string? Fields = null
);
