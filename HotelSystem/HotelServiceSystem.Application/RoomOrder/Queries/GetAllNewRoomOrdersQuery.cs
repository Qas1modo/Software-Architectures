using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models.RoomOrder;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;

namespace HotelServiceSystem.Application.RoomOrder.Queries;

public sealed record GetAllNewRoomOrdersQuery(Guid GuestId) : IQuery<Maybe<List<RoomOrderResponseModel>>>;
