using Bogus;
using BookStore.Domain.Books;
using BookStore.Domain.UnitTests.Abstractions;
using FluentAssertions;

namespace BookStore.Domain.UnitTests.Books
{
    public class BookTests : TestBase
    {
        //[Fact]
        //public void Create_ShouldRaiseDomainEvent_WhenDataIsValid()
        //{
        //    var result = Book.Create(
        //        Faker.Music.Genre(),
        //        Faker.Music.Genre(),
        //        Faker.Person.FullName,
        //        10,
        //        10);

        //    var domainEvent = GetPublishedDomainEvent<BookCreatedDomainEvent>(result);
        //    domainEvent.Should().NotBeNull();
        //    domainEvent.BookId.Should().Be(result.Id);
        //}

        //[Fact]
        //public void UpdatePrice_ShouldUpdatePrice_WhenPriceIsValid()
        //{
        //    var createdBook = Book.Create(
        //        Faker.Music.Genre(),
        //        Faker.Music.Genre(),
        //        Faker.Person.FullName,
        //        10,
        //        10);

        //    createdBook.UpdatePrice(20);

        //    createdBook.Price.Should().Be(20);

        //}
        //[Fact]
        //public void UpdatePrice_ShouldRaiseDomainEvent_WhenPriceIsUpdated()
        //{
        //    var createdBook = Book.Create(
        //        Faker.Music.Genre(),
        //        Faker.Music.Genre(),
        //        Faker.Person.FullName,
        //        10,
        //        10);
        //    createdBook.UpdatePrice(20);

        //    var domainEvent = GetPublishedDomainEvent<BookPriceUpdatedDomainEvent>(createdBook);
        //    domainEvent.Should().NotBeNull();
        //    domainEvent.BookId.Should().Be(createdBook.Id);
        //    domainEvent.NewPrice.Should().Be(createdBook.Price);

        //}
    }
}