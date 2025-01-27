using MediatR;

namespace RoomManagementSystem.BL;

public record class CheckInCommand(int ReservationId) : IRequest<bool>;

