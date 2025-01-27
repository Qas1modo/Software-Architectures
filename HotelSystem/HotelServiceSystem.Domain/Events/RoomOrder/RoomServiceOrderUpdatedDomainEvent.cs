using HotelServiceSystem.Domain.Core.Events;
using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Domain.Events.RoomOrder;

public class RoomServiceOrderUpdatedDomainEvent : IDomainEvent
{
    internal RoomServiceOrderUpdatedDomainEvent(RoomServiceOrderEntity roomServiceOrder) => RoomServiceOrder = roomServiceOrder;

    public RoomServiceOrderEntity RoomServiceOrder { get; }
}
