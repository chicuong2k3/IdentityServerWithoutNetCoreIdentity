namespace BookStore.WebApi.Requests.Users;

public sealed record AddAddressRequest(
    string Town,
    string District,
    string City,
    string AddressLine
);