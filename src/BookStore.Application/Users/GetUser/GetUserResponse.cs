namespace BookStore.Application.Users.GetUser;

public sealed record GetUserResponse(
    Guid Id,
    string Email,
    string FirstName,
    string LastName
);
