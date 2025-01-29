using AutoMapper;
using MediatR;
using RoomManagementSystem.BL.Commands.ReservationCommands;
using RoomManagementSystem.BL.Handlers.CommandHandlers.Base;
using RoomManagementSystem.Contracts.Enums;
using RoomManagementSystem.DAL.EFCore.UnitOfWork;
using RoomManagementSystem.DAL.InfraStructure.UnitOfWork.Interfaces;

namespace RoomManagementSystem.BL.Handlers.CommandHandlers.ReservationCommandHandlers
{
    public class CheckInCommandHandler : ReservationCommandHandler<CheckInCommand, bool>, IRequestHandler<CheckInCommand, bool>
    {
        public CheckInCommandHandler(
            IUnitOfWorkProvider<IEFCoreUnitOfWork> unitOfWorkProvider,
            IMapper mapper)
            : base(unitOfWorkProvider, mapper)
        {
        }
        public async override Task<bool> Handle(CheckInCommand request, CancellationToken cancellationToken)
        {
            using var uow = _unitOfWorkProvider.Create();

            var reservation = await uow.Reservations.GetByIdAsync(request.ReservationId);

            await EnsureReservationExists(uow, request.ReservationId);
            await EnsureRoomExists(uow, reservation.RoomId);

            reservation.State = ReservationState.CheckedIn;
            uow.Reservations.Update(reservation);

            var room = await uow.Rooms.GetByIdAsync(reservation.RoomId);
            room.RoomState = RoomState.Occupied;
            uow.Rooms.Update(room);

            await uow.Commit();
            return true;
        }
    }
}
