namespace BookStore.Application.Users.UpdateUser
{
    internal sealed class UserUpdatedDomainEventHandler()
        : DomainEventHandler<UserUpdatedDomainEvent>
    {
        public override Task Handle(
            UserUpdatedDomainEvent domainEvent,
            CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}
