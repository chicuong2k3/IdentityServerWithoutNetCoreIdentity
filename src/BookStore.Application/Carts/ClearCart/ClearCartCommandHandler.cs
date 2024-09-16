//namespace BookStore.Application.Carts.ClearCart
//{
//    internal sealed class ClearCartCommandHandler(
//        IUserRepository userRepository, 
//        CartService cartService)
//    : ICommandHandler<ClearCartCommand>
//    {
//        public async Task<Result> Handle(ClearCartCommand request, CancellationToken cancellationToken)
//        {
//            var customer = await userRepository.GetAsync(request.CustomerId, cancellationToken);

//            if (customer is null)
//            {
//                return Result.Failure(UserErrors.NotFound(request.CustomerId));
//            }

//            await cartService.ClearCartAsync(customer.Id, cancellationToken);

//            return Result.Success();
//        }
//    }
//}
