using MediatR;

namespace RoomManagementSystem.BL.Commands.ReservationCommands;

public record CheckOutCommand(int ReservationId) : IRequest<bool>;
