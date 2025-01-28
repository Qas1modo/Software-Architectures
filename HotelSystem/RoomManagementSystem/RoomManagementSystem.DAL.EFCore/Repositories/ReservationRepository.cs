using RoomManagementSystem.DAL.EFCore.Database;
using RoomManagementSystem.DAL.EFCore.Entities;
using RoomManagementSystem.DAL.EFCore.Repositories.Base;


namespace RoomManagementSystem.DAL.EFCore.Repositories
{
    public class ReservationRepository(RoomManagementDbContext context) : EFCoreBaseRepository<ReservationEntity>(context)
    {

    }
}
