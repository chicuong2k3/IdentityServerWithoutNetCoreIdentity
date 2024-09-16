namespace BookStore.Application.Abstractions.Identity
{
    public interface IIdentityProviderService
    {
        Task<Guid> RegisterUserAsync(
            string email, 
            string password,
            string firstName,
            string lastName,
            CancellationToken cancellationToken = default);
    }
}
