using AutoMapper;
using MediatR;
using RoomManagementSystem.BL.Commands.ReservationCommands;
using RoomManagementSystem.Contracts;
using RoomManagementSystem.DAL.EFCore.Entities;
using RoomManagementSystem.DAL.EFCore.UnitOfWork;
using RoomManagementSystem.DAL.InfraStructure.UnitOfWork.Interfaces;

namespace RoomManagementSystem.BL.Handlers.CommandHandlers.ReservationCommandHandlers
{
    public class UpdateReservationCommandHandler : ReservationCommandHandler<UpdateReservationCommand, ReservationDetailModel>
    {
        public UpdateReservationCommandHandler(IUnitOfWorkProvider<IEFCoreUnitOfWork> unitOfWorkProvider, IMapper mapper) : base(unitOfWorkProvider, mapper)
        {
        }

        public async override Task<ReservationDetailModel> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            using var uow = _unitOfWorkProvider.Create();

            var updated = _mapper.Map<ReservationEntity>(request.ReservationUpdateModel);
            if(updated.State != Contracts.Enums.ReservationState.Created)
            {
                throw new Exception("Only reservations in Created state can be updated");
            }

            await EnsureReservationExists(uow, request.ReservationUpdateModel.Id);
            await EnsureRoomExists(uow, request.ReservationUpdateModel.RoomId);
            await EnsureRoomAvailable(uow, updated.RoomId, updated.StartDate, updated.EndDate, updated.Id);

            uow.Reservations.Update(updated);
            await uow.Commit();

            return _mapper.Map<ReservationDetailModel>(updated);

        }
    }
}
