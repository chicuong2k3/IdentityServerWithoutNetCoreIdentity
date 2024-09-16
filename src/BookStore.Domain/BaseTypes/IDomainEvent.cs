using MediatR;

namespace BookStore.Domain.BaseTypes
{
    public interface IDomainEvent : INotification
    {
        Guid Id { get; }
        DateTime OccurredOn { get; }
    }
}
