namespace BookStore.Domain.Users
{
    public sealed record Address(
        string Town,
        string District,
        string City,
        string AddressLine
    );
}
