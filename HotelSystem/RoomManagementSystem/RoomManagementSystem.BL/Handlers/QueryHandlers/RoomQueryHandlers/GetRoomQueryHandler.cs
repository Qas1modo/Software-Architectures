using AutoMapper;
using RoomManagementSystem.BL.Handlers.QueryHandlers.Base;
using RoomManagementSystem.BL.Queries.RoomQueries;
using RoomManagementSystem.Contracts;
using RoomManagementSystem.DAL.EFCore.UnitOfWork;
using RoomManagementSystem.DAL.InfraStructure.UnitOfWork.Interfaces;


namespace RoomManagementSystem.BL.Handlers.QueryHandlers.RoomQueryHandlers
{
    public class GetRoomQueryHandler : QueryHandler<GetRoomQuery, RoomDetailModel>
    {
        public GetRoomQueryHandler(IUnitOfWorkProvider<IEFCoreUnitOfWork> unitOfWorkProvider, IMapper mapper) : 
            base(unitOfWorkProvider, mapper)
        {
        }
        public override async Task<RoomDetailModel> Handle(GetRoomQuery request, CancellationToken cancellationToken)
        {
            using var uow = _unitOfWorkProvider.Create();
            var room = await uow.Rooms.GetByIdAsync(request.Id);
            return _mapper.Map<RoomDetailModel>(room);
        }
    }
}
