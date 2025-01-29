using MediatR;
using RoomManagementSystem.Contracts;

namespace RoomManagementSystem.BL.Queries.ReservationQueries;

public record GetReservationsQuery(DateTime From, DateTime To, int Page = -1, int PageSize = -1) : IRequest<IList<ReservationDetailModel>>;
{

}
