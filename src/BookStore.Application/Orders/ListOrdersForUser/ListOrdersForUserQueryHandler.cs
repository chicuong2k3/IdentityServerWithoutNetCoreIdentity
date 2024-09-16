using Dapper;

namespace BookStore.Application.Orders.ListOrdersForUser
{
    internal sealed class ListOrdersForUserQueryHandler(
        IDbConnectionFactory dbConnectionFactory
    )
        : IQueryHandler<ListOrdersForUserQuery, ListOrdersForUserResponse>
    {
        public async Task<Result<ListOrdersForUserResponse>> Handle(ListOrdersForUserQuery query, CancellationToken cancellationToken)
        {
            await using var connection = await dbConnectionFactory.OpenConnectionAsync();

            const string Sql =
                $"""
                SELECT 
                    o.id AS {nameof(OrderSummary.OrderId)},
                    o.customer_id AS {nameof(OrderSummary.CustomerId)},
                    o.created_on {nameof(OrderSummary.CreatedOn)},
                    SUM(oi.quantity * oi.unit_price) AS {nameof(OrderSummary.Total)}
                FROM books.orders o JOIN books.order_items oi ON o.id = oi.order_id
                WHERE o.customer_id = @CustomerId
                GROUP BY o.id
                """;

            var orders = (await connection.QueryAsync<OrderSummary>(Sql, query)).ToList();

            return new ListOrdersForUserResponse(orders);
        }
    }
}
