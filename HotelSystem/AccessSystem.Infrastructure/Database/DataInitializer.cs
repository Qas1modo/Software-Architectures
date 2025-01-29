using AccessSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccessSystem.Infrastructure.Database;

public static class DataInitializer
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var accessCards = modelBuilder.CreateAccessCards();
        var permissions = modelBuilder.CreatePermissions();
        var roles = modelBuilder.CreateRoles();

        modelBuilder.AddPermissionsToRoles(roles, permissions);
        modelBuilder.AddRolesToCards(roles, accessCards);
        modelBuilder.AddExtraPermissionsToCards(permissions, accessCards);
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

    private static List<(Guid Id, PermissionEntity Permission)> CreatePermissions(this ModelBuilder modelBuilder)
    {
        var gymPermission = new PermissionEntity(
            "Gym",
            "Gym",
            "Gym permission"
        );

        var poolPermission = new PermissionEntity(
            "Pool",
            "Pool",
            "Pool permission"
        );

        var maintenancePermission = new PermissionEntity(
            "Maintenance",
            "Maintenance",
            "Maintenance permission"
        );

        var gymPermissionId = Guid.Parse("44444444-4444-4444-4444-444444444444");
        var poolPermissionId = Guid.Parse("55555555-5555-5555-5555-555555555555");
        var maintenancePermissionId = Guid.Parse("66666666-6666-6666-6666-666666666666");
        modelBuilder.Entity<PermissionEntity>().HasData(
            new
            {
                Id = gymPermissionId,
                PermissionCodeName = "Gym",
                PermissionName = "Gym",
                PermissionDescription = "Gym permission"
            },
            new
            {
                Id = poolPermissionId,
                PermissionCodeName = "Pool",
                PermissionName = "Pool",
                PermissionDescription = "Pool permission"
            },
            new
            {
                Id = maintenancePermissionId,
                PermissionCodeName = "Maintenance",
                PermissionName = "Maintenance",
                PermissionDescription = "Maintenance permission"
            }
        );

        return new List<(Guid, PermissionEntity)>
        {
            (gymPermissionId, gymPermission),
            (poolPermissionId, poolPermission),
            (maintenancePermissionId, maintenancePermission)
        };
    }

    private static List<(Guid Id, RoleEntity Role)> CreateRoles(this ModelBuilder modelBuilder)
    {

        // Create Role objects
        var receptionistRole = new RoleEntity(
            "Receptionist",
            "Receptionist",
            "Receptionist role"
        );

        var guestRole = new RoleEntity(
            "Guest",
            "Guest",
            "Guest role"
        );


        var receptionistRoleId = Guid.Parse("77777777-7777-7777-7777-777777777777");
        var guestRoleId = Guid.Parse("88888888-8888-8888-8888-888888888888");
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
                Id = guestRoleId,
                RoleCodeName = "Guest",
                RoleName = "Guest",
                RoleDescription = "Guest role"
            }
        );

        return new List<(Guid, RoleEntity)>
        {
            (receptionistRoleId, receptionistRole),
            (guestRoleId, guestRole)
        };
    }

    public static void AddPermissionsToRoles(this ModelBuilder modelBuilder, List<(Guid Id, RoleEntity Role)> roles,
        List<(Guid Id, PermissionEntity Permission)> permissions)
    {
        var receptionistRole = roles.First(r => r.Role.RoleName == "Receptionist");
        var guestRole = roles.First(r => r.Role.RoleName == "Guest");
        var gymPermission = permissions.First(p => p.Permission.PermissionName == "Gym");
        var poolPermission = permissions.First(p => p.Permission.PermissionName == "Pool");

        modelBuilder.Entity<RolePermission>().HasData(
            new
            {
                Id = Guid.Parse("00000000-1111-1111-1111-111111111111"),
                RoleId = receptionistRole.Id,
                PermissionId = gymPermission.Id
            },
            new
            {
                Id = Guid.Parse("00000000-2222-2222-2222-222222222222"),
                RoleId = receptionistRole.Id,
                PermissionId = gymPermission.Id
            },
            new
            {
                Id = Guid.Parse("00000000-3333-3333-3333-333333333333"),
                RoleId = guestRole.Id,
                PermissionId = poolPermission.Id
            }
        );
    }

    public static void AddRolesToCards(this ModelBuilder modelBuilder, List<(Guid Id, RoleEntity Role)> roles, List<AccessCardEntity> accessCards)
    {
        var receptionistRole = roles.First(r => r.Role.RoleName == "Receptionist");
        var guestRole = roles.First(r => r.Role.RoleName == "Guest");
        var card1 = accessCards[0];
        var card2 = accessCards[1];

        modelBuilder.Entity<AccessCardRole>().HasData(
            new // Card1 -> Receptionist
            {
                Id = Guid.Parse("99999999-1111-1111-1111-111111111111"),
                AccessCardId = card1.Id,
                RoleId = receptionistRole.Id
            },
            new // Card2 -> Guest
            {
                Id = Guid.Parse("99999999-2222-2222-2222-222222222222"),
                AccessCardId = card2.Id,
                RoleId = guestRole.Id
            }
        );
    }

    public static void AddExtraPermissionsToCards(this ModelBuilder modelBuilder, List<(Guid Id, PermissionEntity Permission)> permissions, List<AccessCardEntity> accessCards)
    {
        var maintenancePermission = permissions.First(p => p.Permission.PermissionName == "Maintenance");
        var card1 = accessCards[0];
        var card3 = accessCards[2];

        modelBuilder.Entity<AccessCardPermission>().HasData(
            new
            {
                Id = Guid.Parse("99999999-3333-3333-3333-333333333333"),
                AccessCardId = card1.Id,
                PermissionId = maintenancePermission.Id
            },
            new
            {
                Id = Guid.Parse("99999999-4444-4444-4444-444444444444"),
                AccessCardId = card3.Id,
                PermissionId = maintenancePermission.Id
            }
        );
    }

}