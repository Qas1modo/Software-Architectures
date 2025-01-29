using RoomManagementSystem.Contracts;
using MediatR;
using RoomManagementSystem.BL.Commands.ReservationCommands;
using RoomManagementSystem.BL.Handlers.CommandHandlers.Base;
using AutoMapper;
using RoomManagementSystem.DAL.InfraStructure.UnitOfWork.Interfaces;
using RoomManagementSystem.DAL.EFCore.UnitOfWork;
using RoomManagementSystem.DAL.EFCore.Entities;
using RoomManagementSystem.Contracts.Enums;

namespace RoomManagementSystem.BL.Handlers.CommandHandlers.ReservationCommandHandlers;

public class CreateReservationCommandHandler : ReservationCommandHandler<CreateReservationCommand, ReservationDetailModel>
{
    public CreateReservationCommandHandler(
        IUnitOfWorkProvider<IEFCoreUnitOfWork> unitOfWorkProvider,
        IMapper mapper)
        : base(unitOfWorkProvider, mapper)
    {
    }

    public override async Task<ReservationDetailModel> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        using var uow = _unitOfWorkProvider.Create();
        var reservationModel = request.ReservationCreateModel;

        await EnsureRoomExists(uow, reservationModel.RoomId);
        await EnsureRoomAvailable(uow, reservationModel.RoomId, reservationModel.StartDate, reservationModel.EndDate);

        
        var reservation = _mapper.Map<ReservationEntity>(reservationModel);
        reservation.State = ReservationState.Created;

        uow.Reservations.Insert(reservation);
        await uow.Commit();

        return _mapper.Map<ReservationDetailModel>(reservation);
    }

}

