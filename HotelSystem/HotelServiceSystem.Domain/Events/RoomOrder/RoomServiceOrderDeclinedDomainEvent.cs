using HotelServiceSystem.Domain.Core.Events;
using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Domain.Events.RoomOrder;

public class RoomServiceOrderDeclinedDomainEvent : IDomainEvent
{
    internal RoomServiceOrderDeclinedDomainEvent(RoomServiceOrderEntity roomServiceOrder) => RoomServiceOrder = roomServiceOrder;

    public RoomServiceOrderEntity RoomServiceOrder { get; }
}
