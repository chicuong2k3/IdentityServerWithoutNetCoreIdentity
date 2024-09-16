namespace BookStore.Application.Users.GetUser;

public sealed record GetUserQuery(Guid Id) : IQuery<GetUserResponse>;
