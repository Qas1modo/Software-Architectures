using MediatR;

namespace RoomManagementSystem.BL.Commands.ReservationCommands;

public record CheckInCommand(int ReservationId) : IRequest<bool>;

