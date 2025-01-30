using AutoMapper;
using RoomManagementSystem.BL.Handlers.QueryHandlers.Base;
using RoomManagementSystem.BL.Queries.RoomQueries;
using RoomManagementSystem.Contracts;
using RoomManagementSystem.Contracts.Enums;
using RoomManagementSystem.DAL.EFCore.Entities;
using RoomManagementSystem.DAL.EFCore.UnitOfWork;
using RoomManagementSystem.DAL.InfraStructure.UnitOfWork.Interfaces;
using System.Linq.Expressions;

namespace RoomManagementSystem.BL.Handlers.QueryHandlers.RoomQueryHandlers
{
    public class SearchAvailableRoomsQueryHandler : QueryHandler<SearchAvailableRoomsQuery, IList<RoomListModel>>
    {
        public SearchAvailableRoomsQueryHandler(IUnitOfWorkProvider<IEFCoreUnitOfWork> unitOfWorkProvider, IMapper mapper) :
            base(unitOfWorkProvider, mapper)
        {
        }
        public override async Task<IList<RoomListModel>> Handle(SearchAvailableRoomsQuery request, CancellationToken cancellationToken)
        {
            var filterModel = request.RoomFilterModel;
            using var uow = _unitOfWorkProvider.Create() ;
            

            Expression<Func<RoomEntity, bool>>? filter = (RoomEntity r) =>
                                r.Capacity >= filterModel.MinCapacity
                                && r.BedCount >= filterModel.MinBedCount
                                // ensures that the room is not reserved for the given date range
                                && (!r.Reservations.Any(res =>
                                        (res.State != ReservationState.Cancelled) &&
                                        (res.StartDate <= filterModel.ToDate && res.EndDate >= filterModel.FromDate)
                                    ));
            var rooms = await uow.Rooms.GetAsync(
                filter: filter,
               pageIndex: request.Page,
               pageSize: request.PageSize
                );

            return _mapper.Map<IList<RoomListModel>>(rooms);

        }
    }
}
