using Microsoft.EntityFrameworkCore;
using RoomManagementSystem.DAL.EFCore.Entities;

namespace RoomManagementSystem.DAL.EFCore.Database
{
    public static class DataInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // TODO Seed db
             modelBuilder.Entity<RoomEntity>().HasData(GetSampleRooms());
        }
        public static IList<RoomEntity> GetSampleRooms()
        {
            return [

                ];
        }
    }
}
