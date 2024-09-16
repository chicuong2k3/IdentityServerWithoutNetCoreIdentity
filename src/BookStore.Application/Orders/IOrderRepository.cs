using BookStore.Domain.Orders;

namespace BookStore.Application.Orders
{
    public interface IOrderRepository
    {
        Task<Order?> GetAsync(Guid orderId);
        Task InsertAsync(Order order, CancellationToken cancellationToken = default);
    }
}
