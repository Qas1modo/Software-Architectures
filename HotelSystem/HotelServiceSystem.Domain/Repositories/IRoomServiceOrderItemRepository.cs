using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Domain.Repositories;

public interface IRoomServiceOrderItemRepository
{

    void Insert(RoomServiceOrderItem attendee);

    void Update(RoomServiceOrderItem notification);
}

