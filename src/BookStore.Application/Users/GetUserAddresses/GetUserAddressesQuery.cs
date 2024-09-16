namespace BookStore.Application.Users.GetUserAddresses;

public sealed record GetUserAddressesQuery(Guid UserId) : IQuery<List<UserAddress>>;
