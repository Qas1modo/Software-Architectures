using HotelServiceSystem.DAL.EFCore.Entities;
using HotelServiceSystem.DAL.Infrastructure.Repositories.Interfaces.Base;
using HotelServiceSystem.DAL.Infrastructure.UnitOfWork.Interfaces.Base;

namespace HotelServiceSystem.DAL.EFCore.UnitOfWork;

public interface IEFCoreUnitOfWork : IUnitOfWork
{
    public IEntityRepository<CleanRoomRequestEntity> CleanRoomRequestRepository { get; }
    public IEntityRepository<RoomServiceItemEntity> RoomServiceItemRepository { get; }
    public IEntityRepository<RoomServiceOrderEntity> RoomServiceOrderRepository { get; }
    public IEntityRepository<RoomServiceOrderItemEntity> RoomServiceOrderItemRepository { get; }
    public IEntityRepository<PremiumServiceItemEntity> PremiumServiceItemRepository { get; }
    public IEntityRepository<PremiumServiceOrderEntity> PremiumServiceOrderRepository { get; }
    public IEntityRepository<EmployeeEntity> EmployeeRepository { get; }
    public IEntityRepository<GuestEntity> GuestRepository { get; }
}