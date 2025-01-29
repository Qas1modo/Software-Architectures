using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models.Core;
using HotelServiceSystem.Contracts.Models.RoomServiceModels;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;

namespace HotelServiceSystem.Application.RoomService.Queries;

public sealed record RoomServiceGetAllPagedQuery(GetRoomServicesModel GetRoomServicesModel) : IQuery<Maybe<PagedList<RoomServiceResponseModel>>>;
