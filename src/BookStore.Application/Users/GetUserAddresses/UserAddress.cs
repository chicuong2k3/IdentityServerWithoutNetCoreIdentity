namespace BookStore.Application.Users.GetUserAddresses;

public sealed record UserAddress(
    Guid AddressId,
    string Town,
    string District,
    string City,
    string AddressLine
);