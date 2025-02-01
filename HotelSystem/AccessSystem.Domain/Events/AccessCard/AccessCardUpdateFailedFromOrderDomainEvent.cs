using SharedKernel.Domain.Core.Events;
using SharedKernel.Domain.Core.Primitives;

namespace AccessSystem.Domain.Events.AccessCard;

public class AccessCardUpdateFailedFromOrderDomainEvent(Guid guestId, Guid orderId, Error error) : IDomainEvent
{
    public Guid GuestId { get; } = guestId;
    public Guid OrderId { get; } = orderId;
    public Error Error { get; } = error;
}