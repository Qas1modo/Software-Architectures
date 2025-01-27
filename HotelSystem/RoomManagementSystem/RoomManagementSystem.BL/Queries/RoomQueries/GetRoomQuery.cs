using RoomManagementSystem.Contracts;
using MediatR;

namespace RoomManagementSystem.BL;

public record class GetRoomQuery(int Id) : IRequest<RoomDetailModel>;