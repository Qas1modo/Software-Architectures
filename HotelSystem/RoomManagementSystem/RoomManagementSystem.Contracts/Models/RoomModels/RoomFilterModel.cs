using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomManagementSystem.Contracts.Models.RoomModels
{
    public class RoomFilterModel
    {
        public int MinCapacity { get; set; } = 1;
        public DateTime FromDate { get; set; } = DateTime.Now;
        public DateTime ToDate { get; set; }
        public int MinBedCount { get; set; } = 1;
    }
}
