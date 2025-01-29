using HotelServiceSystem.Domain.Core.Events;
using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Domain.Events.RoomOrder;

public class RoomServiceOrderFulfilledDomainEvent : IDomainEvent
{
    internal RoomServiceOrderFulfilledDomainEvent(RoomServiceOrderEntity roomServiceOrder) => RoomServiceOrder = roomServiceOrder;

    public RoomServiceOrderEntity RoomServiceOrder { get; }
}
