using MediatR;
using RoomManagementSystem.Contracts;
using RoomManagementSystem.Contracts.Models.RoomModels;

namespace RoomManagementSystem.BL.Queries.RoomQueries;

public record SearchAvailableRoomsQuery(RoomFilterModel RoomFilterModel, int Page = -1, int PageSize = -1) : IRequest<IList<RoomListModel>>;

