using BookStore.Application.Carts;

namespace BookStore.Application.Users.AddAddress
{
    public sealed class AddressAddedDomainEventHandler(AddressCacheService addressCacheService)
        : DomainEventHandler<AddressAddedDomainEvent>
    {
        public override async Task Handle(AddressAddedDomainEvent domainEvent, CancellationToken cancellationToken = default)
        {
            await addressCacheService.SetAddressAsync(domainEvent.Address, cancellationToken);
        }
    }

   
}
