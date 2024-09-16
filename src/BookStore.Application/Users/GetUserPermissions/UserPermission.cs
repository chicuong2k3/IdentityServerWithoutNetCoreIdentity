namespace BookStore.Application.Users.GetUserPermissions;

internal sealed class UserPermission
{
    internal Guid UserId { get; init; }
    internal string Permission { get; init; }
}
