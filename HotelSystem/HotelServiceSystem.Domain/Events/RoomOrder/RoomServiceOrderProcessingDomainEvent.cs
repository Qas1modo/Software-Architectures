using HotelServiceSystem.Domain.Core.Events;
using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Domain.Events.RoomOrder;

public class RoomServiceOrderProcessingDomainEvent : IDomainEvent
{
    internal RoomServiceOrderProcessingDomainEvent(RoomServiceOrderEntity roomServiceOrder) => RoomServiceOrder = roomServiceOrder;

    public RoomServiceOrderEntity RoomServiceOrder { get; }
}
