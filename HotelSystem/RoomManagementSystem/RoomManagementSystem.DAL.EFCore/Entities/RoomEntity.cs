using RoomManagementSystem.Contracts.Enums;
using RoomManagementSystem.DAL.EFCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomManagementSystem.DAL.EFCore.Entities
{
    public class RoomEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public int BedCount { get; set; }
        public RoomState RoomState { get; set; }
    }
}
