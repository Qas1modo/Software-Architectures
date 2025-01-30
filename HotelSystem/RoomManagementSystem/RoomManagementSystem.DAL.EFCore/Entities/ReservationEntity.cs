using RoomManagementSystem.Contracts.Enums;
using RoomManagementSystem.DAL.EFCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomManagementSystem.DAL.EFCore.Entities
{
    public class ReservationEntity: BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RoomId { get; set; }
        public virtual RoomEntity Room { get; set; }
        public ReservationType ReservationType { get; set; }
        public ReservationState State { get; set; }
    }
}
