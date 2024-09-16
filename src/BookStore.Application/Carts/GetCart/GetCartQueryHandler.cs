namespace BookStore.Application.Carts.GetCart
{
    internal sealed class GetCartQueryHandler(CartService cartService)
    : IQueryHandler<GetCartQuery, Cart>
    {
        public async Task<Result<Cart>> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            return await cartService.GetCartAsync(request.CustomerId, cancellationToken);
        }
    }
}
