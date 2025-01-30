using AutoMapper;
using MediatR;
using RoomManagementSystem.BL.Commands.ReservationCommands;
using RoomManagementSystem.BL.Handlers.CommandHandlers.Base;
using RoomManagementSystem.Contracts.Enums;
using RoomManagementSystem.DAL.EFCore.UnitOfWork;
using RoomManagementSystem.DAL.InfraStructure.UnitOfWork.Interfaces;

namespace RoomManagementSystem.BL.Handlers.CommandHandlers.ReservationCommandHandlers;

public class CheckOutCommandlHandler : ReservationCommandHandler<CheckOutCommand, bool>, IRequestHandler<CheckOutCommand, bool>
{
    public CheckOutCommandlHandler(
        IUnitOfWorkProvider<IEFCoreUnitOfWork> unitOfWorkProvider,
        IMapper mapper)
        : base(unitOfWorkProvider, mapper)
    {
    }
    public override async Task<bool> Handle(CheckOutCommand request, CancellationToken cancellationToken)
    {
        using var uow = _unitOfWorkProvider.Create();

        var reservation = await uow.Reservations.GetByIdAsync(request.ReservationId);

        await EnsureReservationExists(uow, request.ReservationId);
        await EnsureRoomExists(uow, reservation.RoomId);

        reservation.State = ReservationState.CheckedOut;
        uow.Reservations.Update(reservation);

        var room = await uow.Rooms.GetByIdAsync(reservation.RoomId);
        room.RoomState = RoomState.VacantDirty;
        uow.Rooms.Update(room);

        await uow.Commit();
        return true;
    }
}

