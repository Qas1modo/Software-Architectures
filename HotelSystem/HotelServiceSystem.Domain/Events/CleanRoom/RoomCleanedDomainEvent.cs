using HotelServiceSystem.Domain.Core.Events;
using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Domain.Events.CleanRoom;

public class RoomCleanedDomainEvent : IDomainEvent
{
    internal RoomCleanedDomainEvent(CleanRoomRequestEntity cleanRoomRequest) => CleanRoomRequest = cleanRoomRequest;

    public CleanRoomRequestEntity CleanRoomRequest { get; }
}
