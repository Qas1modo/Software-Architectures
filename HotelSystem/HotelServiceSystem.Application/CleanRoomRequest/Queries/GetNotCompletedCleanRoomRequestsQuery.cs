using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models.CleanRoomRequestModels;
using HotelServiceSystem.Contracts.Models.Core;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;

namespace HotelServiceSystem.Application.CleanRoomRequest.Queries;

public sealed record GetNotCompletedCleanRoomRequestsQuery(GetAllNotCompletedCleanRequestsPagedModel CleanRequestsPagedModel)
    : IQuery<Maybe<PagedList<CleanRoomRequestResponseModel>>>;
