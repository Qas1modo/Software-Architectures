using AutoMapper;
using RoomManagementSystem.BL.Handlers.QueryHandlers.Base;
using RoomManagementSystem.BL.Queries.RoomQueries;
using RoomManagementSystem.Contracts;
using RoomManagementSystem.DAL.EFCore.UnitOfWork;
using RoomManagementSystem.DAL.InfraStructure.UnitOfWork.Interfaces;


namespace RoomManagementSystem.BL.Handlers.QueryHandlers.RoomQueries
{
    public class GetRoomsQueryHandler
        : QueryHandler<GetRoomsQuery, IEnumerable<RoomListModel>>
    {
        public GetRoomsQueryHandler(IUnitOfWorkProvider<IEFCoreUnitOfWork> unitOfWorkProvider, IMapper mapper) :
            base(unitOfWorkProvider, mapper)
        {
        }
        public override async Task<IEnumerable<RoomListModel>> Handle(GetRoomsQuery request, CancellationToken cancellationToken)
        {
            using var uow = _unitOfWorkProvider.Create();
            var rooms = await uow.Rooms.GetAsync(request.Page,request.PageSize);
            return _mapper.Map<IEnumerable<RoomListModel>>(rooms);
        }
    }
}
