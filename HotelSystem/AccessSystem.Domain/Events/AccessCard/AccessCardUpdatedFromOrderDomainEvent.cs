using SharedKernel.Domain.Core.Events;

namespace AccessSystem.Domain.Events.AccessCard;

public class AccessCardUpdatedFromOrderDomainEvent(Guid guestId, Guid orderId) : IDomainEvent
{
    public Guid GuestId { get; } = guestId;
    public Guid OrderId { get; } = orderId;
}