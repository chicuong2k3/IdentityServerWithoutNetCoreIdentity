
namespace BookStore.Domain.Books
{
    public sealed class BookPriceUpdatedDomainEvent(Guid bookId, decimal newPrice) : DomainEvent
    {
        public Guid BookId { get; init; } = bookId;
        public decimal NewPrice { get; init; } = newPrice;
    }
}