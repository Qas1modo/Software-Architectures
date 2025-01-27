using MediatR;

namespace RoomManagementSystem.BL;

public record class CheckOutCommand(int ReservationId) : IRequest<bool>;
