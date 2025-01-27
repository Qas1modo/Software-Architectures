using RoomManagementSystem.Contracts;
using MediatR;

namespace RoomManagementSystem.BL;

public record class CreateReservationCommand(ReservationCreateModel ReservationCreateModel) : IRequest<ReservationDetailModel>;
