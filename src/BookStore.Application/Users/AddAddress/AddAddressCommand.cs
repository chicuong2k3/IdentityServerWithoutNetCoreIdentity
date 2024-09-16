namespace BookStore.Application.Users.AddAddress
{
    public sealed record AddAddressCommand(
        Guid UserId,
        string Town,
        string District,    
        string City,
        string AddressLine
    ) : ICommand;
}
