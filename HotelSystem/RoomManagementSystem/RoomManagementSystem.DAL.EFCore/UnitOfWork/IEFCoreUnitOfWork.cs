

using RoomManagementSystem.DAL.EFCore.Entities;
using RoomManagementSystem.DAL.EFCore.Repositories;
using RoomManagementSystem.DAL.InfraStructure.Repositories;
using RoomManagementSystem.DAL.InfraStructure.Repositories.Interfaces.Base;
using RoomManagementSystem.DAL.InfraStructure.UnitOfWork.Interfaces.Base;

namespace RoomManagementSystem.DAL.EFCore.UnitOfWork
{
    public interface IEFCoreUnitOfWork : IUnitOfWork
    {
        public IBaseRepository<ReservationEntity> Reservations { get; }
        public IBaseRepository<RoomEntity> Rooms { get; }

    }
}
