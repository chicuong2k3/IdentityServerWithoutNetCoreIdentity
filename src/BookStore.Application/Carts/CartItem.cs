namespace BookStore.Application.Carts
{
    public sealed class CartItem
    {
        public Guid BookId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}