namespace BookStore.WebApi.Requests.Users;

public sealed record UpdateUserProfileRequest(
    string FirstName,
    string LastName
);
