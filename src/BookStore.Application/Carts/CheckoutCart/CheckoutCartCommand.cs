namespace BookStore.Application.Carts.CheckoutCart
{
    public sealed record CheckoutCartCommand(
        Guid CustomerId,
        Guid ShippingAddressId
    ) : ICommand<CheckoutCartResponse>;
}
