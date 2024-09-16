namespace BookStore.Domain.Orders
{
    public sealed record Address(
        string Town, 
        string District, 
        string City, 
        string AddressLine);
}
