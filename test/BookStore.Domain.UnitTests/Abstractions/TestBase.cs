using Bogus;
using BookStore.Domain.BaseTypes;

namespace BookStore.Domain.UnitTests.Abstractions
{
    public class TestBase
    {
        protected static readonly Faker Faker = new();
        public static T GetPublishedDomainEvent<T>(Entity entity)
            where T : IDomainEvent
        {
            var domainEvent = entity.DomainEvents.OfType<T>().SingleOrDefault();

            if (domainEvent == null)
            {
                throw new Exception($"{typeof(T).Name} was not published.");
            }

            return domainEvent;
        }

    }
}
