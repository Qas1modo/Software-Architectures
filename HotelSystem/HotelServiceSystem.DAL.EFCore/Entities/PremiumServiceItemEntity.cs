using HotelServiceSystem.DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelServiceSystem.DAL.EFCore.Entities
{
    public class PremiumServiceItemEntity : Entity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Image { get; set; }
        public decimal Price { get; set; }
        public required string RelevantRoleCodeName { get; set; }

    }
}
