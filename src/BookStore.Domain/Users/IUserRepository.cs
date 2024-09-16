namespace BookStore.Domain.Users
{
    public interface IUserRepository
    {
        Task<User?> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<User?> GetUserWithAddressesAsync(Guid id, CancellationToken cancellationToken = default);

        void Insert(User user);
        Task<UserAddress?> GetShippingAddressAsync(Guid shippingAddressId, CancellationToken cancellationToken = default);
    }
}
