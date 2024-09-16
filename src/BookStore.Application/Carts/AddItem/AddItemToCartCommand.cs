namespace BookStore.Application.Carts.AddItem
{
    public sealed record AddItemToCartCommand(
        Guid CustomerId,
        Guid BookId,
        int Quantity) : ICommand;
}
