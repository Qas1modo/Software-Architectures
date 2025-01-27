using BillingSystem.DAL.Infrastructure.Repositories.Interfaces.Base;
using RoomManagementSystem.DAL.EFCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomManagementSystem.DAL.InfraStructure.Repositories
{
    public class RoomRepository : IEntityRepository<RoomEntity>
    {
        public Task<RoomEntity?> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(RoomEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(object id)
        {
            throw new NotImplementedException();
        }

        public void Update(RoomEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
