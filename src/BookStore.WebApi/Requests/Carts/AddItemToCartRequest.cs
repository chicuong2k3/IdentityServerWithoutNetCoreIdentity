namespace BookStore.WebApi.Requests.Carts;

public sealed record AddItemToCartRequest(
    Guid BookId,
    int Quantity
);
