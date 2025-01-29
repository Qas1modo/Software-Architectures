using MediatR;
using RoomManagementSystem.BL.Handlers.CommandHandlers.Base;
using RoomManagementSystem.BL.Commands.ReservationCommands;
using RoomManagementSystem.DAL.InfraStructure.UnitOfWork.Interfaces;
using AutoMapper;
using RoomManagementSystem.DAL.EFCore.UnitOfWork;
using RoomManagementSystem.Contracts.Enums;

namespace RoomManagementSystem.BL.Handlers.CommandHandlers.ReservationCommandHandlers;

public class CancelReservationCommandHandler : ReservationCommandHandler<CancelReservationCommand, bool>, IRequestHandler<CancelReservationCommand, bool>
{
    public CancelReservationCommandHandler(IUnitOfWorkProvider<IEFCoreUnitOfWork> unitOfWorkProvider, IMapper mapper)
        : base(unitOfWorkProvider, mapper)
    {
    }

    public override async Task<bool> Handle(CancelReservationCommand request, CancellationToken cancellationToken)
    {
        using var uow = _unitOfWorkProvider.Create();
        await EnsureReservationExists(uow, request.Id);

        var reservation = await uow.Reservations.GetByIdAsync(request.Id);
        reservation.State = ReservationState.Cancelled;

        uow.Reservations.Update(reservation);

        await uow.Commit();
        return true;
    }
}

