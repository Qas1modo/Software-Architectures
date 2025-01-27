using MediatR;
using RoomManagementSystem.Contracts;

namespace RoomManagementSystem.BL;

public record class UpdateReservationCommand(ReservationUpdateModel ReservationUpdateModel) : IRequest<ReservationDetailModel>;
