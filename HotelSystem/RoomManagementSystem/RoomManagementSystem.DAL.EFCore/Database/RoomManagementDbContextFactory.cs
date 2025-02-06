using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomManagementSystem.DAL.EFCore.Database
{
    public class RoomManagementDbContextFactory : IDesignTimeDbContextFactory<RoomManagementDbContext>
    {
        public RoomManagementDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RoomManagementDbContext>();
            optionsBuilder.UseSqlite("Data Source=RoomManagement.db");

            return new RoomManagementDbContext(optionsBuilder.Options);
        }
    }
}
