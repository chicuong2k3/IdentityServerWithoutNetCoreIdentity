namespace BookStore.Domain.Books
{
    public sealed class BookCreatedDomainEvent(Guid bookId) : DomainEvent
    {
        public Guid BookId { get; init; } = bookId;
    }
}
