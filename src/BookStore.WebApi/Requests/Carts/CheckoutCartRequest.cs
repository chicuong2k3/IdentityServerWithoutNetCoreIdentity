namespace BookStore.WebApi.Requests.Carts;

public sealed record CheckoutCartRequest(
      Guid ShippingAddressId
);