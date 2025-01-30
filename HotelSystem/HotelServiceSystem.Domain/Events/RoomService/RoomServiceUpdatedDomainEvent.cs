using HotelServiceSystem.Domain.Core.Events;
using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Domain.Events.RoomService;

public class RoomServiceUpdatedDomainEvent : IDomainEvent
{
    internal RoomServiceUpdatedDomainEvent(RoomServiceEntity roomService) => RoomService = roomService;

    public RoomServiceEntity RoomService { get; }
}
