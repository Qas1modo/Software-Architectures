using MediatR;
using RoomManagementSystem.Contracts;

namespace RoomManagementSystem.BL;

public record class GetAllRoomsQuery(int Page = -1, int PageSize = -1): IRequest<List<RoomListModel>>;
