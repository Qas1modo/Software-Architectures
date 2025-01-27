using MediatR;
using RoomManagementSystem.Contracts;

namespace RoomManagementSystem.BL;

public record class CancelReservationCommand(int Id) : IRequest<bool>;

