using HotelServiceSystem.DAL.Entities.Base;
using HotelServiceSystem.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelServiceSystem.DAL.EFCore.Entities
{
    public class EmployeeEntity : Entity
    {
        public string Name { get; set; }
        public EmployeeTypeEnum EmployeeType { get; set; }
    }
}
