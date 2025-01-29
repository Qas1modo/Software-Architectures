using RoomManagementSystem.Contracts;
using MediatR;

namespace RoomManagementSystem.BL.Commands.ReservationCommands;

public record CreateReservationCommand(ReservationCreateModel ReservationCreateModel) : IRequest<ReservationDetailModel>;
