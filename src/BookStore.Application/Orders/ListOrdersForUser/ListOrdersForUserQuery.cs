namespace BookStore.Application.Orders.ListOrdersForUser
{
    public sealed record ListOrdersForUserQuery(Guid CustomerId) : IQuery<ListOrdersForUserResponse>;
}
