using AutoMapper;
using MediatR;
using RoomManagementSystem.BL.Handlers.CommandHandlers.Base;
using RoomManagementSystem.Contracts.Enums;
using RoomManagementSystem.DAL.EFCore.UnitOfWork;
using RoomManagementSystem.DAL.InfraStructure.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RoomManagementSystem.BL.Handlers.CommandHandlers.ReservationCommandHandlers
{
    public abstract class ReservationCommandHandler<TCommand, TResult> : CommandHandler<TCommand, TResult> where TCommand : IRequest<TResult>
    {
        protected ReservationCommandHandler(IUnitOfWorkProvider<IEFCoreUnitOfWork> unitOfWorkProvider, IMapper mapper) : base(unitOfWorkProvider, mapper)
        {
        }
        protected async Task EnsureRoomExists(IEFCoreUnitOfWork uow, int roomId)
        {
            _ = await uow.Rooms.GetByIdAsync(roomId) ?? throw new Exception("Room not found");
        }
        protected async Task EnsureReservationExists(IEFCoreUnitOfWork uow, int reservationId)
        {
            _ = await uow.Reservations.GetByIdAsync(reservationId) ?? throw new Exception("Reservation not found");
        }
        protected async Task EnsureRoomAvailable(IEFCoreUnitOfWork uow, int roomId, DateTime fromDate, DateTime toDate, int? excludeReservationId = null)
        {
            if (!await IsRoomAvailable(uow, roomId, fromDate, toDate, excludeReservationId))
            {
                throw new Exception("Room is not available for the selected dates");
            }
        }
        protected async Task<bool> IsRoomAvailable(
            IEFCoreUnitOfWork uow,
            int roomId,
            DateTime fromDate,
            DateTime toDate,
            int? excludeReservationId = null) // Optional parameter to exclude current reservation when updating
        {
            var conflictingReservations = await uow.Reservations.GetAsync(
                filter: r => r.RoomId == roomId
                    && r.StartDate < toDate
                    && r.EndDate > fromDate
                    && (!excludeReservationId.HasValue || r.Id != excludeReservationId)
                    && r.State != ReservationState.Cancelled);

            return !conflictingReservations.Any();
        }
    }
}
