//namespace BookStore.Application.Users.UpdateUser;
//internal sealed class UpdateUserProfileCommandHandler(
//    IUserRepository userRepository,
//    IUnitOfWork unitOfWork)
//    : ICommandHandler<UpdateUserProfileCommand>
//{
//    public async Task<Result> Handle(UpdateUserProfileCommand command, CancellationToken cancellationToken)
//    {
//        var user = await userRepository.GetAsync(command.Id, cancellationToken);

//        if (user is null)
//        {
//            return Result.Failure(UserErrors.NotFound(command.Id));
//        }

//        user.Update(command.FirstName, command.LastName);

//        await unitOfWork.SaveChangesAsync(cancellationToken);

//        return Result.Success();
//    }

//}
