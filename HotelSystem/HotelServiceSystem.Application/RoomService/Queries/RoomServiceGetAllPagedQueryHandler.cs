using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models.Core;
using HotelServiceSystem.Contracts.Models.RoomServiceModels;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;
using HotelServiceSystem.Domain.Repositories;

namespace HotelServiceSystem.Application.RoomService.Queries;

internal sealed class RoomServiceGetAllPagedQueryHandler(IRoomServiceRepository roomServiceRepository) 
    : IQueryHandler<RoomServiceGetAllPagedQuery, Maybe<PagedList<RoomServiceResponseModel>>>
{
    private readonly IRoomServiceRepository roomServiceRepository = roomServiceRepository;

    public async Task<Maybe<PagedList<RoomServiceResponseModel>>> Handle(RoomServiceGetAllPagedQuery request,
        CancellationToken cancellationToken)
    {
        return await roomServiceRepository.GetAllRoomServicesAsync(request.GetRoomServicesModel, cancellationToken);
    }
}