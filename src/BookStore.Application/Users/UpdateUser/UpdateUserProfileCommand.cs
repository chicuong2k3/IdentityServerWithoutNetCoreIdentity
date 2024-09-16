namespace BookStore.Application.Users.UpdateUser;

public sealed record UpdateUserProfileCommand(
    Guid Id,
    string FirstName,
    string LastName
) : ICommand;
