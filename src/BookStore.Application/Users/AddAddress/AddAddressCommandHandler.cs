//namespace BookStore.Application.Users.AddAddress
//{
//    internal sealed class AddAddressCommandHandler(
//        IUserRepository userRepository,
//        IUnitOfWork unitOfWork
//    ) : ICommandHandler<AddAddressCommand>
//    {
//        public async Task<Result> Handle(AddAddressCommand command, CancellationToken cancellationToken)
//        {  
//            var user = await userRepository.GetUserWithAddressesAsync(command.UserId, cancellationToken);

//            if (user is null)
//            {
//                return Result.Failure(UserErrors.NotFound(command.UserId));
//            }

//            var address = new Address(command.Town, command.District, command.City, command.AddressLine);

//            user.AddAddress(address);

//            await unitOfWork.SaveChangesAsync(cancellationToken);

//            return Result.Success();
//        }
//    }   
//}
