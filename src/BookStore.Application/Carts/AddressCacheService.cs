using BookStore.Application.Abstractions.Caching;

namespace BookStore.Application.Carts
{
    public sealed class AddressCacheService(
        ICacheService cacheService)
    {
        public async Task<UserAddress?> GetAddressAsync(Guid addressId, CancellationToken cancellationToken)
        {
            var address = await cacheService.GetAsync<UserAddress>(addressId.ToString(), cancellationToken);

            return address;
        }

        public async Task SetAddressAsync(UserAddress address, CancellationToken cancellationToken)
        {
            await cacheService.SetAsync(address.Id.ToString(), address, null, cancellationToken);
        }
    }
}
