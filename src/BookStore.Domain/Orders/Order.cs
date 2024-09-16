namespace BookStore.Domain.Orders
{
    public sealed class Order : Entity
    {
        private List<OrderItem> orderItems = [];
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public Address ShippingAddress { get; private set; }
        public DateTime CreatedOn { get; set; }

        public IReadOnlyCollection<OrderItem> OrderItems => [..orderItems];
        private Order()
        {
            
        }

        public static Order Create(
            Guid customerId, 
            Address shippingAddress,
            IEnumerable<OrderItem> orderItems)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                CustomerId = customerId,
                ShippingAddress = shippingAddress,
                CreatedOn = DateTime.UtcNow
            };

            foreach (var orderItem in orderItems)
            {
                order.AddOrderItem(orderItem);
            }

            order.Raise(new OrderCreatedDomainEvent(order.Id));


            return order;
        }

        private void AddOrderItem(OrderItem orderItem)
        {
            orderItems.Add(orderItem);
        }
    }
}
