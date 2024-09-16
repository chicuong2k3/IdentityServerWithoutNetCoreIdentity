//using BookStore.Application.Abstractions.Identity;

//namespace BookStore.Application.Users.RegisterUser;
//internal sealed class RegisterUserCommandHandler(
//    IUserRepository userRepository,
//    IUnitOfWork unitOfWork,
//    IIdentityProviderService identityProviderService)
//    : ICommandHandler<RegisterUserCommand, Guid>
//{
//    public async Task<Result<Guid>> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
//    {
//        var result = await identityProviderService.RegisterUserAsync(
//            command.Email,
//            command.Password,
//            command.FirstName,
//            command.LastName,
//            cancellationToken);

//        if (result.IsFailure)
//        {
//            return Result.Failure<Guid>(result.Error);
//        }

//        var user = User.Create(command.Email, command.FirstName, command.LastName, result.Value);
//        userRepository.Insert(user);


//        await unitOfWork.SaveChangesAsync(cancellationToken);

//        return user.Id;
//    }

//}
