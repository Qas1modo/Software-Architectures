using HotelServiceSystem.Contracts.Models.Core;
using HotelServiceSystem.Contracts.Models.RoomServiceModels;
using HotelServiceSystem.Domain.Core.Primitives;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;
using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Domain.Repositories;

public interface IRoomServiceRepository
{
    Task<Maybe<PagedList<RoomServiceResponseModel>>> GetAllRoomServicesAsync(GetRoomServicesModel getRoomServicesModel,
    CancellationToken cancellationToken);

    Task<Maybe<RoomServiceEntity>> GetByIdAsync(Guid id);

    void Remove(RoomServiceEntity roomService);

    void Insert(RoomServiceEntity roomService);

    void Update(RoomServiceEntity roomService);
}
