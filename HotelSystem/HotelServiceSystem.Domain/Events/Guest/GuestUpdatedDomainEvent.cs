using HotelServiceSystem.Domain.Core.Events;
using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Domain.Events.Guest;

public class GuestUpdatedDomainEvent : IDomainEvent
{
    internal GuestUpdatedDomainEvent(GuestEntity guest) => Guest = guest;

    public GuestEntity Guest { get; }
}
