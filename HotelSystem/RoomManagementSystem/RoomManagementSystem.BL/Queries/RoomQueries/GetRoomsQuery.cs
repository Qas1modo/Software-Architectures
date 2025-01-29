using MediatR;
using RoomManagementSystem.Contracts;

namespace RoomManagementSystem.BL.Queries.RoomQueries;

public record GetRoomsQuery(int Page = -1, int PageSize = -1): IRequest<IList<RoomListModel>>;
