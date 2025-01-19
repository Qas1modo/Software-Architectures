using HotelServiceSystem.DAL.EFCore.Database;
using HotelServiceSystem.DAL.EFCore.Entities;
using HotelServiceSystem.DAL.EFCore.Repositories.Base;
using HotelServiceSystem.DAL.Infrastructure.Repositories.Interfaces.Base;

namespace HotelServiceSystem.DAL.EFCore.UnitOfWork.Base;

public class EFCoreUnitOfWork : IEFCoreUnitOfWork
{
    protected readonly ApplicationDbContext _dbContext;

    public EFCoreUnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;

        CleanRoomRequestRepository = new EFCoreEntityRepository<CleanRoomRequestEntity>(_dbContext);
        RoomServiceItemRepository = new EFCoreEntityRepository<RoomServiceItemEntity>(_dbContext);
        RoomServiceOrderRepository = new EFCoreEntityRepository<RoomServiceOrderEntity>(_dbContext);
        RoomServiceOrderItemRepository = new EFCoreEntityRepository<RoomServiceOrderItemEntity>(_dbContext);
        PremiumServiceItemRepository = new EFCoreEntityRepository<PremiumServiceItemEntity>(_dbContext);
        PremiumServiceOrderRepository = new EFCoreEntityRepository<PremiumServiceOrderEntity>(_dbContext);
        EmployeeRepository = new EFCoreEntityRepository<EmployeeEntity>(_dbContext);
        GuestRepository = new EFCoreEntityRepository<GuestEntity>(_dbContext);
    }

    public IEntityRepository<CleanRoomRequestEntity> CleanRoomRequestRepository { get; }

    public IEntityRepository<RoomServiceItemEntity> RoomServiceItemRepository { get; }

    public IEntityRepository<RoomServiceOrderEntity> RoomServiceOrderRepository { get; }

    public IEntityRepository<RoomServiceOrderItemEntity> RoomServiceOrderItemRepository { get; }

    public IEntityRepository<PremiumServiceItemEntity> PremiumServiceItemRepository { get; }

    public IEntityRepository<PremiumServiceOrderEntity> PremiumServiceOrderRepository { get; }

    public IEntityRepository<EmployeeEntity> EmployeeRepository { get; }

    public IEntityRepository<GuestEntity> GuestRepository { get; }

    public async Task Commit()
    {
        await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}