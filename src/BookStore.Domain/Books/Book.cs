
namespace BookStore.Domain.Books
{
    public class Book : Entity
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Isbn { get; private set; }
        public string Author { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public int CategoryId { get; private set; }
        public Guid OwnerId { get; private set; }
        private Book()
        {

        }
        public static Book Create(
            string title, 
            string description,
            string isbn,
            string author, 
            decimal price,
            int quantity,
            int categoryId)
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = Guard.Against.NullOrWhiteSpace(title),
                Description = Guard.Against.NullOrWhiteSpace(description),
                Isbn = Guard.Against.NullOrWhiteSpace(isbn),
                Author = Guard.Against.NullOrWhiteSpace(author),
                Price = Guard.Against.Negative(price),
                Quantity = Guard.Against.NegativeOrZero(quantity),
                CategoryId = Guard.Against.NegativeOrZero(categoryId)
            };

            book.Raise(new BookCreatedDomainEvent(book.Id));

            return book;
        }

        public void UpdatePrice(decimal newPrice)
        {
            Price = Guard.Against.Negative(newPrice);

            Raise(new BookPriceUpdatedDomainEvent(Id, Price));
        }
    }
}
