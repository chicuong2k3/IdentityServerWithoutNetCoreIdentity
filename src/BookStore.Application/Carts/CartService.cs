using BookStore.Application.Abstractions.Caching;

namespace BookStore.Application.Carts
{
    public sealed class CartService(ICacheService cacheService)
    {
        public async Task<Cart> GetCartAsync(Guid customerId, CancellationToken cancellationToken = default)
        {
            var key = CreateCartKey(customerId);
            var cart = await cacheService.GetAsync<Cart>(key, cancellationToken)
                ?? Cart.CreateDefault(customerId);

            return cart;
        }

        public async Task ClearCartAsync(Guid customerId, CancellationToken cancellationToken = default)
        {
            var key = CreateCartKey(customerId);
            var cart = Cart.CreateDefault(customerId);
            await cacheService.SetAsync(key, cart, cancellationToken: cancellationToken);
        }

        public async Task AddItemAsync(Guid customerId, CartItem cartItem, CancellationToken cancellationToken = default)
        {
            var key = CreateCartKey(customerId);
            var cart = await GetCartAsync(customerId, cancellationToken);

            var existingCartItem = cart.CartItems.Find(x => x.BookId == cartItem.BookId);

            if (existingCartItem is null)
            {
                cart.CartItems.Add(cartItem);
            }
            else
            {
                existingCartItem.Quantity += cartItem.Quantity;
            }

            await cacheService.SetAsync(key, cart, cancellationToken: cancellationToken);
        }

        public async Task RemoveItemAsync(Guid customerId, Guid bookId, int Quantity, CancellationToken cancellationToken = default)
        {
            var key = CreateCartKey(customerId);
            var cart = await GetCartAsync(customerId, cancellationToken);

            var existingCartItem = cart.CartItems.Find(x => x.BookId == bookId);

            if (existingCartItem is null)
            {
                return;
            }

            if (existingCartItem.Quantity > Quantity)
            {
                existingCartItem.Quantity -= Quantity;
            }
            else
            {
                cart.CartItems.Remove(existingCartItem);
            }

            await cacheService.SetAsync(key, cart, cancellationToken: cancellationToken);
        }

        static string CreateCartKey(Guid customerId) => $"carts:{customerId}";
    }
}
