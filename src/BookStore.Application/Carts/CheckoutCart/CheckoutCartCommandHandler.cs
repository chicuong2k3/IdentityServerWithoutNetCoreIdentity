//using BookStore.Application.Orders.CreateOrder;
//using BookStore.Domain.Books;
//using MediatR;

//namespace BookStore.Application.Carts.CheckoutCart
//{
//    internal class CheckoutCartCommandHandler(
//        IUserRepository userRepository,
//        IBookRepository bookRepository,
//        CartService cartService,
//        AddressCacheService addressCacheService,
//        ISender sender
//    )
//        : ICommandHandler<CheckoutCartCommand, CheckoutCartResponse>
//    {
//        public async Task<Result<CheckoutCartResponse>> Handle(CheckoutCartCommand command, CancellationToken cancellationToken)
//        {
//            var customer = await userRepository.GetAsync(command.CustomerId, cancellationToken);
//            if (customer is null)
//            {
//                   return Result.Failure<CheckoutCartResponse>(UserErrors.NotFound(command.CustomerId));
//            }

//            var shippingAddress = await addressCacheService.GetAddressAsync(
//                command.ShippingAddressId,
//                cancellationToken);

//            if (shippingAddress is null)
//            {
//                return Result.Failure<CheckoutCartResponse>(UserErrors.ShippingAddressNotFound(command.ShippingAddressId));
//            }

//            var orderItemTasks = (await cartService.GetCartAsync(command.CustomerId))
//                .CartItems.Select(async x =>
//                {
//                    var book = await bookRepository.GetAsync(x.BookId, cancellationToken);

//                    if (book is null)
//                    {
//                        throw new InvalidOperationException($"The book with id {x.BookId} was not found.");
//                    }

//                    return new OrderItemDetails(
//                        x.BookId,
//                        x.Quantity,
//                        book.Price,
//                        book.Description
//                    );
//                });

//            var orderItems = (await Task.WhenAll(orderItemTasks)).ToList();


//            var createOrderCommand = new CreateOrderCommand(
//                customer.Id,
//                new Domain.Orders.Address(
//                    shippingAddress.Address.Town,
//                    shippingAddress.Address.District,
//                    shippingAddress.Address.City,
//                    shippingAddress.Address.AddressLine
//                ),
//                orderItems
//            );
             
//            var result = await sender.Send(createOrderCommand, cancellationToken);

//            if (result.IsFailure)
//            {
//                return Result.Failure<CheckoutCartResponse>(result.Error);
//            }

//            await cartService.ClearCartAsync(command.CustomerId, cancellationToken);

//            return Result.Success(new CheckoutCartResponse(result.Value));
//        }
//    }
//}
