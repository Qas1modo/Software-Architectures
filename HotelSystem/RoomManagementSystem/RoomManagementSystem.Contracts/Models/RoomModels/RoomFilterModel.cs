using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomManagementSystem.Contracts.Models.RoomModels
{
    public class RoomFilterModel
    {
        public int MinCapacity { get; set; }
        public int FromDate { get; set; }
        public int ToDate { get; set; }
        public int MinBedCount { get; set; }
    }
}
