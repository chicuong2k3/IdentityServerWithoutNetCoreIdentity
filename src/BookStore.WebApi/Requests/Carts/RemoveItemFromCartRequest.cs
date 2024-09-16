namespace BookStore.WebApi.Requests.Carts;

public sealed record RemoveItemFromCartRequest(
    Guid BookId,
    int Quantity
);