using MediatR;
using RoomManagementSystem.Contracts;

namespace RoomManagementSystem.BL.Queries.ReservationQueries;

public record GetReservationQuery(int Id) : IRequest<ReservationDetailModel>;
