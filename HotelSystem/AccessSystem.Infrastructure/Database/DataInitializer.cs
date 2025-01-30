using AccessSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccessSystem.Infrastructure.Database;

public static class DataInitializer
{
    public const int ROOM_COUNT = 20;
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var accessCards = modelBuilder.CreateAccessCards();
        var roles = modelBuilder.CreateRoles();

        modelBuilder.AddRolesToCards(roles, accessCards);
        modelBuilder.CreateAccessClaims(roles);
    }

    private static List<AccessCardEntity> CreateAccessCards(this ModelBuilder modelBuilder)
    {

        var card1 = new AccessCardEntity(Guid.Parse("11111111-1111-1111-1111-111111111111"), Guid.Parse("00000000-0000-0000-0000-000000000001"));
        var card2 = new AccessCardEntity(Guid.Parse("22222222-2222-2222-2222-222222222222"), Guid.Parse("00000000-0000-0000-0000-000000000002"));
        var card3 = new AccessCardEntity(Guid.Parse("33333333-3333-3333-3333-333333333333"), Guid.Parse("00000000-0000-0000-0000-000000000003"));
        modelBuilder.Entity<AccessCardEntity>().HasData(
            card1,
            card2,
            card3
        );

        return [card1, card2, card3];
    }

    private static List<(Guid Id, RoleEntity Role)> CreateRoles(this ModelBuilder modelBuilder)
    {

        // Create Role objects
        var receptionistRole = new RoleEntity(
            "Receptionist",
            "Receptionist",
            "Receptionist role"
        );

        var maintenanceRole = new RoleEntity(
            "Maintenance",
            "Maintenance staff",
            "Maintenance staff"
        );
        
        var cleaningStaffRole = new RoleEntity(
            "CleaningStaff",
            "Cleaning staff",
            "Cleaning staff"
        );
        
        var royalBuffet = new RoleEntity(
            "RoyalBuffet",
            "Royal buffet",
            "Access to the royal buffet"
        );


        var royalBuffetRoleId = Guid.Parse("66666666-6666-6666-6666-666666666666");
        var receptionistRoleId = Guid.Parse("77777777-7777-7777-7777-777777777777");
        var maintenanceRoleId = Guid.Parse("88888888-8888-8888-8888-888888888888");
        var cleaningStaffRoleId = Guid.Parse("99999999-9999-9999-9999-999999999999");
        modelBuilder.Entity<RoleEntity>().HasData(
            new
            {
                Id = receptionistRoleId,
                RoleCodeName = "Receptionist",
                RoleName = "Receptionist",
                RoleDescription = "Receptionist role"
            },
            new
            {
                Id = maintenanceRoleId,
                RoleCodeName = "Maintenance",
                RoleName = "Maintenance staff",
                RoleDescription = "Maintenance staff"
            },
            new
            {
                Id = cleaningStaffRoleId,
                RoleCodeName = "CleaningStaff",
                RoleName = "Cleaning staff",
                RoleDescription = "Cleaning staff"
            },
            new
            {
                Id = royalBuffetRoleId,
                RoleCodeName = "RoyalBuffet",
                RoleName = "Royal buffet",
                RoleDescription = "Access to the royal buffet"
            }
        );

        var result = new List<(Guid, RoleEntity)>
        {
            (receptionistRoleId, receptionistRole),
            (maintenanceRoleId, maintenanceRole),
            (cleaningStaffRoleId, cleaningStaffRole),
            (royalBuffetRoleId, royalBuffet)
        };
        for (int i = 1; i <= ROOM_COUNT; i++)
        {
            var roomNumber = i.ToString("D3");
            var guidString = $"00000000-0000-0000-0000-000000000{roomNumber}";
            var guid = Guid.Parse(guidString);
            
            var roomRole = new RoleEntity(
                $"Room{roomNumber}",
                $"Room {roomNumber}",
                $"Access to room {roomNumber}"
            );
            
            modelBuilder.Entity<RoleEntity>().HasData(
                new
                {
                    Id = guid,
                    RoleCodeName = $"Room{roomNumber}",
                    RoleName = $"Room {roomNumber}",
                    RoleDescription = $"Access to room {roomNumber}"
                }
            );
            
            result.Add((guid, roomRole));
        }

        return result;
    }
    

    public static void AddRolesToCards(this ModelBuilder modelBuilder, List<(Guid Id, RoleEntity Role)> roles, List<AccessCardEntity> accessCards)
    {
        var receptionistRole = roles.First(r => r.Role.RoleCodeName == "Receptionist");
        var royalBuffetRole = roles.First(r => r.Role.RoleCodeName == "RoyalBuffet");
        var room1Role = roles.First(r => r.Role.RoleCodeName == "Room001");
        var card1 = accessCards[0];
        var card2 = accessCards[1];

        modelBuilder.Entity<AccessCardRole>().HasData(
            new // Card1 -> Receptionist
            {
                Id = Guid.Parse("99999999-1111-1111-1111-111111111111"),
                AccessCardId = card1.Id,
                RoleId = receptionistRole.Id
            },
            new // Card2 -> RoyalBuffet
            {
                Id = Guid.Parse("99999999-2222-2222-2222-222222222222"),
                AccessCardId = card2.Id,
                RoleId = royalBuffetRole.Id
            },
            new // Card2 -> Room001
            {
                Id = Guid.Parse("99999999-3333-3333-3333-333333333333"),
                AccessCardId = card2.Id,
                RoleId = room1Role.Id
            }
        );
    }

    public static void CreateAccessClaims(this ModelBuilder modelBuilder, List<(Guid Id, RoleEntity Role)> roles)
    {
        var receptionistRole = roles.First(r => r.Role.RoleCodeName == "Receptionist");
        var maintenanceRole = roles.First(r => r.Role.RoleCodeName == "Maintenance");
        var cleaningStaffRole = roles.First(r => r.Role.RoleCodeName == "CleaningStaff");
        
        modelBuilder.Entity<AccessClaimEntity>().HasData(
            new
            {
                Id = Guid.Parse("42004200-4200-4200-4200-111111111111"),
                CodeName = "ReceptionAccess"
            },
            new
            {
                Id = Guid.Parse("42004200-4200-4200-4200-222222222222"),
                CodeName = "MaintenanceAccess"
            },
            new
            {
                Id = Guid.Parse("42004200-4200-4200-4200-333333333333"),
                CodeName = "RoyalBuffetHallAccess"
            }
        );
        
        modelBuilder.Entity<AccessClaimRole>().HasData(
            new
            {
                Id = Guid.Parse("42004200-4200-4200-4200-999999999999"),
                AccessClaimId = Guid.Parse("42004200-4200-4200-4200-111111111111"),
                RoleId = receptionistRole.Id
            },
            new
            {
                Id = Guid.Parse("42004200-4200-0000-4200-999999999999"),
                AccessClaimId = Guid.Parse("42004200-4200-4200-4200-111111111111"),
                RoleId = cleaningStaffRole.Id
            },
            new
            {
                Id = Guid.Parse("42004200-4200-4200-4200-888888888888"),
                AccessClaimId = Guid.Parse("42004200-4200-4200-4200-222222222222"),
                RoleId = maintenanceRole.Id
            },
            new
            {
                Id = Guid.Parse("42004200-4200-0000-4200-888888888888"),
                AccessClaimId = Guid.Parse("42004200-4200-4200-4200-111111111111"),
                RoleId = cleaningStaffRole.Id
            },
            new
            {
                Id = Guid.Parse("42004200-4200-4200-4200-777777777777"),
                AccessClaimId = Guid.Parse("42004200-4200-4200-4200-333333333333"),
                RoleId = receptionistRole.Id
            },
            new
            {
                Id = Guid.Parse("42004200-4200-0000-4200-777777777777"),
                AccessClaimId = Guid.Parse("42004200-4200-4200-4200-111111111111"),
                RoleId = cleaningStaffRole.Id
            }
        );

        for (int i = 1; i <= ROOM_COUNT; i++)
        {
            var roomNumber = i.ToString("D3");
            var guidString = $"42004200-4200-4200-4200-000000000{roomNumber}";
            var guid = Guid.Parse(guidString);
            modelBuilder.Entity<AccessClaimEntity>().HasData(
                new
                {
                    Id = guid,
                    CodeName = $"Room{roomNumber}Access"
                }
            );
            
            var roomRole = roles.First(r => r.Role.RoleCodeName == $"Room{roomNumber}");
            modelBuilder.Entity<AccessClaimRole>().HasData(
                new
                {
                    Id = Guid.Parse($"42004200-4200-4200-4200-999999999{roomNumber}"),
                    AccessClaimId = guid,
                    RoleId = roomRole.Id
                },
                new
                {
                    Id = Guid.Parse($"42004200-4200-4200-0000-999999999{roomNumber}"),
                    AccessClaimId = guid,
                    RoleId = cleaningStaffRole.Id
                }
            );
        }

    }
}