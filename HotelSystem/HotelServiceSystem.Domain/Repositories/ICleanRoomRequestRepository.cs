using HotelServiceSystem.Contracts.Models.CleanRoomRequestModels;
using HotelServiceSystem.Contracts.Models.Core;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Domain.Repositories;

public interface ICleanRoomRequestRepository
{
    void Insert(CleanRoomRequestEntity cleanRoomRequestEntity);

    Task<Result> MarkAsCompleted(Guid cleanRoomRequestId);

    Task<Maybe<PagedList<CleanRoomRequestResponseModel>>> GetNotCompletedRequests(GetAllNotCompletedCleanRequestsPagedModel pagination, CancellationToken cancellationToken);
}

