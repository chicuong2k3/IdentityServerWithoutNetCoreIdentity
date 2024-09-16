//using BookStore.Domain.Books;

//namespace BookStore.Application.Carts.AddItem
//{
//    internal sealed class AddItemToCartCommandHandler(
//    CartService cartService,
//    IUserRepository userRepository,
//    IBookRepository bookRepository)
//    : ICommandHandler<AddItemToCartCommand>
//    {
//        public async Task<Result> Handle(AddItemToCartCommand command, CancellationToken cancellationToken)
//        {
//            var customer = await userRepository.GetAsync(command.CustomerId, cancellationToken);
//            if (customer is null)
//            {
//                return Result.Failure(UserErrors.NotFound(command.CustomerId));
//            }

//            var book = await bookRepository.GetAsync(command.BookId, cancellationToken);
//            if (book is null)
//            {
//                return Result.Failure(BookErrors.NotFound(command.BookId));
//            }


//            var cartItem = new CartItem()
//            {
//                BookId = book.Id,
//                Price = book.Price,
//                Quantity = command.Quantity
//            };

//            await cartService.AddItemAsync(customer.Id, cartItem, cancellationToken);

//            return Result.Success();
//        }
//    }
//}
