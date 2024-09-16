namespace BookStore.Application.Orders.ListOrdersForUser
{
    public sealed record OrderSummary(
        Guid OrderId,
        Guid CustomerId,
        DateTime CreatedOn,
        decimal Total
    );
}
