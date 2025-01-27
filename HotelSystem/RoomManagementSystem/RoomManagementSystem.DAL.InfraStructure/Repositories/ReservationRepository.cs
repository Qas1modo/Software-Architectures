using BillingSystem.DAL.Infrastructure.Repositories.Interfaces.Base;
using RoomManagementSystem.DAL.EFCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomManagementSystem.DAL.InfraStructure.Repositories
{
    public class ReservationRepository : IEntityRepository<ReservationEntity>
    {
        public Task<ReservationEntity?> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(ReservationEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(object id)
        {
            throw new NotImplementedException();
        }

        public void Update(ReservationEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
