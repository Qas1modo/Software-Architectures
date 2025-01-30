using MediatR;
using RoomManagementSystem.Contracts;

namespace RoomManagementSystem.BL.Commands.ReservationCommands
{
    public record UpdateReservationCommand(ReservationUpdateModel ReservationUpdateModel) : IRequest<ReservationDetailModel>;

}