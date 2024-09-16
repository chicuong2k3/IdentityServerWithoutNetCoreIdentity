namespace BookStore.WebApi.Requests.Users;

public sealed record RegisterUserRequest(
    string Email,
    string Password,
    string FirstName,
    string LastName
);