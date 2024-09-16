
namespace BookStore.Domain.Users
{
    public sealed class AddressAddedDomainEvent(Guid userId, UserAddress address) : DomainEvent
    {
        public Guid UserId { get; init; } = userId;
        public UserAddress Address { get; init; } = address;
    }
}