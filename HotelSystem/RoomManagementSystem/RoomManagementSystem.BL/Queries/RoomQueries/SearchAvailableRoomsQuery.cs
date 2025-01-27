using MediatR;
using RoomManagementSystem.Contracts;
using RoomManagementSystem.Contracts.Models.RoomModels;

namespace RoomManagementSystem.BL;

public record class SearchAvailableRoomsQuery(RoomFilterModel RoomFilterModel) : IRequest<IEnumerable<RoomListModel>>;

