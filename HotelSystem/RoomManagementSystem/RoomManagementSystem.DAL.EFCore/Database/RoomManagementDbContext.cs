using Microsoft.EntityFrameworkCore;
using RoomManagementSystem.DAL.EFCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomManagementSystem.DAL.EFCore.Database
{
    public class RoomManagementDbContext: DbContext
    {
        public DbSet<RoomEntity> Rooms { get; set; }
        public DbSet<ReservationEntity> Reservations { get; set; }
        public RoomManagementDbContext(DbContextOptions<RoomManagementDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
}
