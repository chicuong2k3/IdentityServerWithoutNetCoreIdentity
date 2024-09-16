namespace BookStore.Application.Orders.ListOrdersForUser
{
    public sealed record ListOrdersForUserResponse(
        List<OrderSummary> Orders
    );
}
