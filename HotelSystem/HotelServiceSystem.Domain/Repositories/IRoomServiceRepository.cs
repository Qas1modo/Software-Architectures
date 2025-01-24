using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Domain.Repositories;

public interface IRoomServiceRepository
{

    void Insert(RoomService roomService);

    void Update(RoomService roomService);
}
