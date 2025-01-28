using RoomManagementSystem.DAL.EFCore.Database;
using RoomManagementSystem.DAL.EFCore.Entities;

namespace RoomManagementSystem.DAL.InfraStructure.Repositories
{
    public class RoomRepository(RoomManagementDbContext context) : EFCoreBaseRepository<RoomEntity>(context);
}
