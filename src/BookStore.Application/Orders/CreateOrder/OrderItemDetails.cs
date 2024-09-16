namespace BookStore.Application.Orders.CreateOrder
{
    public sealed record OrderItemDetails(
        Guid BookId, 
        int Quantity,
        decimal UnitPrice,
        string? Description
    );
}
