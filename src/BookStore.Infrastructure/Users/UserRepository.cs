//namespace BookStore.Infrastructure.Users
//{
//    internal sealed class UserRepository(AppDbContext context) : IUserRepository
//    {
//        public async Task<User?> GetAsync(Guid id, CancellationToken cancellationToken = default)
//        {
//            return await context.Users.FindAsync(id);
//        }
//        public async Task<User?> GetUserWithAddressesAsync(Guid id, CancellationToken cancellationToken = default)
//        {
//            return await context.Users
//                .Include(x => x.Addresses)
//                .Where(x => x.Id == id)
//                .SingleOrDefaultAsync();
//        }

//        public async Task<UserAddress?> GetShippingAddressAsync(Guid shippingAddressId, CancellationToken cancellationToken = default)
//        {
//            return await context.UserAddresses.FindAsync(shippingAddressId, cancellationToken);
//        }

//        public void Insert(User user)
//        {
//            foreach (var role in user.Roles)
//            {
//                context.Attach(role);
//            }

//            context.Users.Add(user);
//        }
//    }
//}
