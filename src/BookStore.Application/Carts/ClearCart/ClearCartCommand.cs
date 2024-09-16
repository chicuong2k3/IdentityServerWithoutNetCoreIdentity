

namespace BookStore.Application.Carts.ClearCart
{
    public sealed record ClearCartCommand(Guid CustomerId) : ICommand;
}
