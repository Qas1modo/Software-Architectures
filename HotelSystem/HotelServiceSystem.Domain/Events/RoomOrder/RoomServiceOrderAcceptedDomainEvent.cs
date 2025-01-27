using HotelServiceSystem.Domain.Core.Events;
using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Domain.Events.RoomOrder;

public class RoomServiceOrderAcceptedDomainEvent : IDomainEvent
{
    internal RoomServiceOrderAcceptedDomainEvent(RoomServiceOrderEntity roomServiceOrder) => RoomServiceOrder = roomServiceOrder;

    public RoomServiceOrderEntity RoomServiceOrder { get; }
}
