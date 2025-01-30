using RoomManagementSystem.Contracts;
using MediatR;

namespace RoomManagementSystem.BL.Queries.RoomQueries;

public record GetRoomQuery(int Id) : IRequest<RoomDetailModel>;