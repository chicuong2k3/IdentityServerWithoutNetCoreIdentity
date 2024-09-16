namespace BookStore.Domain.Users
{
    public sealed class User : Entity
    {
        private readonly List<Role> roles = [];
        private readonly List<UserAddress> addresses = [];
        private User()
        {

        }
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string IdentityId { get; private set; }

        public IReadOnlyCollection<Role> Roles => [.. roles];
        public IReadOnlyCollection<UserAddress> Addresses => addresses;
        public static User Create(string email, string firstName, string lastName, string identityId)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = Guard.Against.NullOrWhiteSpace(email),
                FirstName = Guard.Against.NullOrWhiteSpace(firstName),
                LastName = Guard.Against.NullOrWhiteSpace(lastName),
                IdentityId = Guard.Against.NullOrWhiteSpace(identityId)
            };

            user.roles.Add(Role.Member);

            user.Raise(new UserRegisteredDomainEvent(user.Id));

            return user;
        }

        public void Update(string firstName, string lastName)
        {

            if (FirstName != firstName || LastName != lastName)
            {
                FirstName = Guard.Against.NullOrWhiteSpace(firstName);
                LastName = Guard.Against.NullOrWhiteSpace(lastName);
                Raise(new UserUpdatedDomainEvent(Id, FirstName, LastName));
            }

        }

        public void AddAddress(Address address)
        {
            Guard.Against.Null(address);

            if (addresses.Any(x => x.Address == address))
            {
                return;
            }

            var userAddress = new UserAddress(Id, address);

            addresses.Add(userAddress);

            Raise(new AddressAddedDomainEvent(Id, userAddress));
        }
    }
}
