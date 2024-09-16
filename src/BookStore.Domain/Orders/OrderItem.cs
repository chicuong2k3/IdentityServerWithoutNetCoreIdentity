using Ardalis.GuardClauses;

namespace BookStore.Domain.Orders
{
    public sealed class OrderItem
    {
        public Guid Id { get; private set; }
        public Guid BookId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public string? Description { get; private set; }
        private OrderItem()
        {
            
        }
        public OrderItem(Guid bookId, int quantity, decimal unitPrice, string? description)
        {
            Id = Guid.NewGuid();
            BookId = Guard.Against.Default(bookId);
            Quantity = Guard.Against.NegativeOrZero(quantity);
            UnitPrice = Guard.Against.Negative(unitPrice);
            Description = description;
        }
    }
}
