using AutoMapper;
using RoomManagementSystem.BL.Handlers.QueryHandlers.Base;
using RoomManagementSystem.BL.Queries.RoomQueries;
using RoomManagementSystem.Contracts;
using RoomManagementSystem.DAL.EFCore.UnitOfWork;
using RoomManagementSystem.DAL.InfraStructure.UnitOfWork.Interfaces;


namespace RoomManagementSystem.BL.Handlers.QueryHandlers.RoomQueryHandlers
{
    public class GetRoomsQueryHandler
        : QueryHandler<GetRoomsQuery, IList<RoomListModel>>
    {
        public GetRoomsQueryHandler(IUnitOfWorkProvider<IEFCoreUnitOfWork> unitOfWorkProvider, IMapper mapper) :
            base(unitOfWorkProvider, mapper)
        {
        }
        public override async Task<IList<RoomListModel>> Handle(GetRoomsQuery request, CancellationToken cancellationToken)
        {
            using var uow = _unitOfWorkProvider.Create();
            var rooms = await uow.Rooms.GetAsync(request.Page,request.PageSize);
            return _mapper.Map<IList<RoomListModel>>(rooms);
        }
    }
}
