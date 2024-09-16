using BookStore.Domain.UnitTests.Abstractions;
using BookStore.Domain.Users;
using FluentAssertions;

namespace BookStore.Domain.UnitTests.Users
{
    public class UserTests : TestBase
    {
        [Fact]
        public void Create_ShouldRaiseDomainEvent_WhenDataIsValid()
        {
            var result = User.Create(
                Faker.Person.Email,
                Faker.Person.FirstName,
                Faker.Person.LastName,
                Guid.NewGuid().ToString());

            var domainEvent = GetPublishedDomainEvent<UserRegisteredDomainEvent>(result);
            domainEvent.Should().NotBeNull();
            domainEvent.UserId.Should().Be(result.Id);
        }
        [Fact]
        public void Update_ShouldUpdateLastNameAndFirstName_WhenDataIsValid()
        {
            var oldFirstName = Faker.Person.FirstName;
            var oldLastName = Faker.Person.LastName;

            var createdUser = User.Create(
                Faker.Person.Email,
                oldFirstName,
                oldLastName,
                Guid.NewGuid().ToString());

            
            createdUser.Update(Faker.Music.Genre(), Faker.Music.Genre());

            createdUser.FirstName.Should().NotBe(oldFirstName);
            createdUser.LastName.Should().NotBe(oldLastName);

        }
        [Fact]
        public void Update_ShouldRaiseDomainEvent_WhenDataIsValid()
        {
            var oldFirstName = Faker.Person.FirstName;
            var oldLastName = Faker.Person.LastName;

            var createdUser = User.Create(
                Faker.Person.Email,
                oldFirstName,
                oldLastName,
                Guid.NewGuid().ToString());

            var newFirstName = Faker.Music.Genre();
            var newLastName = Faker.Music.Genre();
            createdUser.Update(newFirstName, newLastName);

            var domainEvent = GetPublishedDomainEvent<UserUpdatedDomainEvent>(createdUser);
            domainEvent.Should().NotBeNull();
            domainEvent.UserId.Should().Be(createdUser.Id);
            domainEvent.FirstName.Should().Be(newFirstName);
            domainEvent.LastName.Should().Be(newLastName);
        }
    }
}
