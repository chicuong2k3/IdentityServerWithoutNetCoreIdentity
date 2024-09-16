using BookStore.Domain.Orders;

namespace BookStore.Application.Orders.CreateOrder
{
    internal class CreateOrderCommandHandler(
        IOrderRepository orderRepository
    )
        : ICommandHandler<CreateOrderCommand, Guid>
    {
        public async Task<Result<Guid>> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            
            var orderItems = command.OrderItems.Select(item => new OrderItem(
                item.BookId, 
                item.Quantity, 
                item.UnitPrice, 
                item.Description)
            );

            var order = Order.Create(command.CustomerId, command.ShippingAddress, orderItems);

            await orderRepository.InsertAsync(order, cancellationToken);

            return Result.Success(order.Id);

        }
    }
}
