namespace BookStore.Domain.Users
{
    public sealed class UserAddress : Entity
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Address Address { get; private set; }
        public UserAddress() { }
        public UserAddress(Guid userId, Address address)
        {
            Id = Guid.NewGuid();
            UserId = Guard.Against.Default(userId);
            Address = Guard.Against.Null(address);
        }
    }
}
