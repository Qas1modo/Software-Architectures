using Microsoft.EntityFrameworkCore;
using RoomManagementSystem.Contracts.Enums;
using RoomManagementSystem.DAL.EFCore.Entities;

namespace RoomManagementSystem.DAL.EFCore.Database
{
    public static class DataInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // TODO Seed db
            modelBuilder.Entity<RoomEntity>().HasData(GetSampleRooms());
            modelBuilder.Entity<ReservationEntity>().HasData(GetSampleReservations());
        }
        public static IList<RoomEntity> GetSampleRooms()
        {
            return
        [
            new RoomEntity
            {
                Id = 1,
                Name = "Deluxe Room 101",
                Description = "Spacious room with city view and king-size bed",
                Capacity = 2,
                Price = 199.99m,
                BedCount = 1,
                RoomState = RoomState.VacantReady,
                CreatedAt = DateTime.UtcNow,
            },
            new RoomEntity
            {
                Id = 2,
                Name = "Family Suite 201",
                Description = "Large suite with two bedrooms and living area",
                Capacity = 4,
                Price = 349.99m,
                BedCount = 2,
                RoomState = RoomState.VacantReady,
                CreatedAt = DateTime.UtcNow,
            },
            new RoomEntity
            {
                Id = 3,
                Name = "Standard Room 102",
                Description = "Comfortable room with twin beds",
                Capacity = 2,
                Price = 149.99m,
                BedCount = 2,
                RoomState = RoomState.VacantDirty,
                CreatedAt = DateTime.UtcNow,
            },
            new RoomEntity
            {
                Id = 4,
                Name = "Executive Suite 301",
                Description = "Luxury suite with private balcony",
                Capacity = 2,
                Price = 299.99m,
                BedCount = 1,
                RoomState = RoomState.OutOfService,
                CreatedAt = DateTime.UtcNow,
            },
            new RoomEntity
            {
                Id = 5,
                Name = "Economy Room 103",
                Description = "Budget-friendly room with basic amenities",
                Capacity = 1,
                Price = 99.99m,
                BedCount = 1,
                RoomState = RoomState.Occupied,
                CreatedAt = DateTime.UtcNow,
            }
        ];
        }

        public static IList<ReservationEntity> GetSampleReservations()
        {
            var currentDate = DateTime.UtcNow;

            return
        [
            // Room 1 (VacantReady) - Past checked out and future reservation
            new ReservationEntity
            {
                Id = 1,
                StartDate = currentDate.AddDays(-5),
                EndDate = currentDate.AddDays(-2),
                RoomId = 1,
                ReservationType = ReservationType.Leisure,
                State = ReservationState.CheckedOut,
                CreatedAt = currentDate.AddDays(-10)
            },
            new ReservationEntity
            {
                Id = 2,
                StartDate = currentDate.AddDays(5),
                EndDate = currentDate.AddDays(7),
                RoomId = 1,
                ReservationType = ReservationType.Business,
                State = ReservationState.Created,
                CreatedAt = currentDate.AddDays(-1)
            },

            // Room 2 (VacantReady) - Cancelled and future reservation
            new ReservationEntity
            {
                Id = 3,
                StartDate = currentDate.AddDays(-3),
                EndDate = currentDate.AddDays(-1),
                RoomId = 2,
                ReservationType = ReservationType.Leisure,
                State = ReservationState.Cancelled,
                CreatedAt = currentDate.AddDays(-10)
            },
            new ReservationEntity
            {
                Id = 4,
                StartDate = currentDate.AddDays(10),
                EndDate = currentDate.AddDays(15),
                RoomId = 2,
                ReservationType = ReservationType.Leisure,
                State = ReservationState.Created,
                CreatedAt = currentDate.AddDays(-2)
            },

            // Room 3 (VacantDirty) - Just checked out
            new ReservationEntity
            {
                Id = 5,
                StartDate = currentDate.AddDays(-3),
                EndDate = currentDate,
                RoomId = 3,
                ReservationType = ReservationType.Business,
                State = ReservationState.CheckedOut,
                CreatedAt = currentDate.AddDays(-10)
            },
            new ReservationEntity
            {
                Id = 6,
                StartDate = currentDate.AddDays(20),
                EndDate = currentDate.AddDays(25),
                RoomId = 3,
                ReservationType = ReservationType.Business,
                State = ReservationState.Created,
                CreatedAt = currentDate.AddDays(-1)
            },

            // Room 4 (OutOfService) - Maintenance reservation
            new ReservationEntity
            {
                Id = 7,
                StartDate = currentDate,
                EndDate = currentDate.AddDays(7),
                RoomId = 4,
                ReservationType = ReservationType.Maintenance,
                State = ReservationState.CheckedIn,
                CreatedAt = currentDate.AddDays(-1)
            },

            // Room 5 (Occupied) - Current active reservation
            new ReservationEntity
            {
                Id = 8,
                StartDate = currentDate.AddDays(-1),
                EndDate = currentDate.AddDays(3),
                RoomId = 5,
                ReservationType = ReservationType.Leisure,
                State = ReservationState.CheckedIn,
                CreatedAt = currentDate.AddDays(-5)
            },
            new ReservationEntity
            {
                Id = 9,
                StartDate = currentDate.AddDays(10),
                EndDate = currentDate.AddDays(12),
                RoomId = 5,
                ReservationType = ReservationType.Business,
                State = ReservationState.Created,
                CreatedAt = currentDate.AddDays(-2)
            }
        ];
    
        }
    }
}
