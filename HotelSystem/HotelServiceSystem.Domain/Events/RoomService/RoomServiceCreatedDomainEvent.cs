using HotelServiceSystem.Domain.Core.Events;
using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Domain.Events.RoomService;

public class RoomServiceCreatedDomainEvent : IDomainEvent
{
    internal RoomServiceCreatedDomainEvent(RoomServiceEntity roomService) => RoomService = roomService;

    public RoomServiceEntity RoomService { get; }
}
