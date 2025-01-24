using HotelServiceSystem.Domain.Core.Events;
using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Domain.Events
{
    public record RoomServiceOrderCreatedDomainEvent(RoomServiceOrder RoomServiceOrder) : IDomainEvent;
}
