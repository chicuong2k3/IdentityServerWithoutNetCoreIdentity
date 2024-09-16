
namespace BookStore.Application.Orders.CreateOrder
{
    public sealed record CreateOrderCommand(
        Guid CustomerId,
        Domain.Orders.Address ShippingAddress,
        List<OrderItemDetails> OrderItems
    ) : ICommand<Guid>;
}
