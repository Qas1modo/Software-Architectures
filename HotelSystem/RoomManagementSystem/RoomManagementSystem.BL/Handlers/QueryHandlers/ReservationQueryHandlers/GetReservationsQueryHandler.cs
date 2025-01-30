using AutoMapper;
using RoomManagementSystem.BL.Handlers.QueryHandlers.Base;
using RoomManagementSystem.BL.Queries.ReservationQueries;
using RoomManagementSystem.Contracts;
using RoomManagementSystem.DAL.EFCore.Entities;
using RoomManagementSystem.DAL.EFCore.UnitOfWork;
using RoomManagementSystem.DAL.InfraStructure.UnitOfWork.Interfaces;
using System.Linq.Expressions;

namespace RoomManagementSystem.BL.Handlers.QueryHandlers.ReservationQueryHandlers
{
    public class GetReservationsQueryHandler : QueryHandler<GetReservationsQuery, IList<ReservationListModel>>
    {
        public GetReservationsQueryHandler(IUnitOfWorkProvider<IEFCoreUnitOfWork> unitOfWorkProvider, IMapper mapper) :
            base(unitOfWorkProvider, mapper)
        {
        }

        public override async Task<IList<ReservationListModel>> Handle(GetReservationsQuery request, CancellationToken cancellationToken)
        {
            using var uow = _unitOfWorkProvider.Create();
            Expression<Func<ReservationEntity, bool>> filter = x =>
            x.StartDate >= request.To 
            && x.EndDate <= request.From;

            var reservations = await uow.Reservations.GetAsync(request.Page, request.PageSize, filter);

            return _mapper.Map<IList<ReservationListModel>>(reservations);
        }

    }
}
