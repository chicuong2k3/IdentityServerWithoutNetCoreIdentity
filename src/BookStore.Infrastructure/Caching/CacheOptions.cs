using Microsoft.Extensions.Caching.Distributed;

namespace BookStore.Infrastructure.Caching
{
    public class CacheOptions
    {
        public static DistributedCacheEntryOptions DefaultExpiration => new()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2)
        };

        public static DistributedCacheEntryOptions Create(TimeSpan? expiration) =>
        expiration != null ? new()
        {
            AbsoluteExpirationRelativeToNow = expiration
        } : DefaultExpiration;
    }
}
