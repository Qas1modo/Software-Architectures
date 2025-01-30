using Microsoft.EntityFrameworkCore.Storage;
using RoomManagementSystem.DAL.EFCore.Database;
using RoomManagementSystem.DAL.EFCore.Entities;
using RoomManagementSystem.DAL.EFCore.Repositories.Base;
using RoomManagementSystem.DAL.InfraStructure.Repositories.Interfaces.Base;
using RoomManagementSystem.DAL.InfraStructure.UnitOfWork.Interfaces.Base;

namespace RoomManagementSystem.DAL.EFCore.UnitOfWork.Base
{
    public class EFCoreUnitOfWork : IEFCoreUnitOfWork
    {
        protected readonly RoomManagementDbContext _context;

        public EFCoreUnitOfWork(RoomManagementDbContext context)
        {
            _context = context;

            Reservations = new EFCoreBaseRepository<ReservationEntity>(_context);
            Rooms = new EFCoreBaseRepository<RoomEntity>(_context);
        }
        public IBaseRepository<ReservationEntity> Reservations { get; }
        public IBaseRepository<RoomEntity> Rooms { get; }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
