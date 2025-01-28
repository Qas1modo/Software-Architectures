using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models.CleanRoomRequestModels;
using HotelServiceSystem.Contracts.Models.Core;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;
using HotelServiceSystem.Domain.Repositories;

namespace HotelServiceSystem.Application.CleanRoomRequest.Queries;

internal sealed class GetNotCompletedCleanRoomRequestsQueryHandler(ICleanRoomRequestRepository cleanRoomRequestRepository)
    : IQueryHandler<GetNotCompletedCleanRoomRequestsQuery, Maybe<PagedList<CleanRoomRequestResponseModel>>>
{

    public async Task<Maybe<PagedList<CleanRoomRequestResponseModel>>> Handle(GetNotCompletedCleanRoomRequestsQuery request,
        CancellationToken cancellationToken)
    {
        return await cleanRoomRequestRepository.GetNotCompletedRequests(request.CleanRequestsPagedModel, cancellationToken);
    }
}