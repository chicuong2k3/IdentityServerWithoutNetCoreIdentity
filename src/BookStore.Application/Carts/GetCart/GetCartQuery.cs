namespace BookStore.Application.Carts.GetCart
{
    public sealed record GetCartQuery(Guid CustomerId) : IQuery<Cart>;
}
