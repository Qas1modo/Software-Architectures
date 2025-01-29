using MediatR;
using RoomManagementSystem.Contracts;

namespace RoomManagementSystem.BL.Commands.ReservationCommands;

public record CancelReservationCommand(int Id) : IRequest<bool>;

