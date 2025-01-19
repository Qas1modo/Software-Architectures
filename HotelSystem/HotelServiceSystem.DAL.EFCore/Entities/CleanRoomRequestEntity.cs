using HotelServiceSystem.DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelServiceSystem.DAL.EFCore.Entities
{
    public class CleanRoomRequestEntity : Entity
    {
        public DateTime Deadline { get; set; }
        public int RoomNumber { get; set; }
        public Guid? EmployeeGuid { get; set; }
        public EmployeeEntity? AssignedEmployee { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
