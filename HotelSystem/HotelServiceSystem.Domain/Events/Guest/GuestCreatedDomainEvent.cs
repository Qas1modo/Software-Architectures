using HotelServiceSystem.Domain.Core.Events;
using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Domain.Events.Guest;

public class GuestCreatedDomainEvent : IDomainEvent
{
    internal GuestCreatedDomainEvent(GuestEntity guest) => Guest = guest;

    public GuestEntity Guest { get; }
}
