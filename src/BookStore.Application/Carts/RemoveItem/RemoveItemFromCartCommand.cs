namespace BookStore.Application.Carts.RemoveItem
{
    public sealed record RemoveItemFromCartCommand(
        Guid CustomerId,
        Guid BookId,
        int Quantity) : ICommand;
}
