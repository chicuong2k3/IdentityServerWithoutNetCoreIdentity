namespace BookStore.Application.Users.RegisterUser
{
    internal sealed class UserRegisteredDomainEventHandler()
        : DomainEventHandler<UserRegisteredDomainEvent>
    {
        public override Task Handle(
            UserRegisteredDomainEvent domainEvent,
            CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

    }
}
