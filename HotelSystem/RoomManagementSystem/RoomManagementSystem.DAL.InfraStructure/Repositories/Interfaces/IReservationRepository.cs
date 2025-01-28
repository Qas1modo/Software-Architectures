using RoomManagementSystem.DAL.EFCore.Entities;
using RoomManagementSystem.DAL.InfraStructure.Repositories.Interfaces.Base;


namespace RoomManagementSystem.DAL.InfraStructure.Repositories.Interfaces
{
    public interface IReservationRepository: IBaseRepository<ReservationEntity>
    {
    }
}
