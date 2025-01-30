using AutoMapper;
using RoomManagementSystem.BL.Handlers.QueryHandlers.Base;
using RoomManagementSystem.BL.Queries.ReservationQueries;
using RoomManagementSystem.Contracts;
using RoomManagementSystem.DAL.EFCore.UnitOfWork;
using RoomManagementSystem.DAL.InfraStructure.UnitOfWork.Interfaces;


namespace RoomManagementSystem.BL.Handlers.QueryHandlers.ReservationQueryHandlers
{
    public class GetReservationQueryHandler : QueryHandler<GetReservationQuery, ReservationDetailModel>
    {
        public GetReservationQueryHandler(IUnitOfWorkProvider<IEFCoreUnitOfWork> unitOfWorkProvider, IMapper mapper) :
            base(unitOfWorkProvider, mapper)
        {
        }
        public override async Task<ReservationDetailModel> Handle(GetReservationQuery request, CancellationToken cancellationToken)
        {
            using var uow = _unitOfWorkProvider.Create();
            var reservation = await uow.Reservations.GetByIdAsync(request.Id);
            return _mapper.Map<ReservationDetailModel>(reservation);
        }
    
    }
}
