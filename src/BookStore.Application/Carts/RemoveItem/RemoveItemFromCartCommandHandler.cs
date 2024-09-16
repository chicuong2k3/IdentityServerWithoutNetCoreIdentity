//using BookStore.Domain.Books;

//namespace BookStore.Application.Carts.RemoveItem
//{
//    internal sealed class RemoveItemFromCartCommandHandler(
//    CartService cartService,
//    IUserRepository userRepository,
//    IBookRepository bookRepository)
//    : ICommandHandler<RemoveItemFromCartCommand>
//    {
//        public async Task<Result> Handle(RemoveItemFromCartCommand command, CancellationToken cancellationToken)
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


//            await cartService.RemoveItemAsync(customer.Id, book.Id, command.Quantity, cancellationToken);

//            return Result.Success();
//        }
//    }
//}
