using BookStore.Application.Orders;
using BookStore.Domain.Orders;

namespace BookStore.Infrastructure.Orders
{
    internal sealed class OrderRepository(AppDbContext context) : IOrderRepository
    {
        public async Task<Order?> GetAsync(Guid orderId)
        {
            return await context.Orders.FindAsync(orderId);
        }
        public async Task InsertAsync(Order order, CancellationToken cancellationToken = default)
        {
            context.Orders.Add(order);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
