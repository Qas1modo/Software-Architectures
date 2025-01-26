using AccessSystem.Domain.Entities;
using AccessSystem.Domain.ValueObjects;
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

    private static List<AccessCard> CreateAccessCards(this ModelBuilder modelBuilder)
    {

        var card1 = new AccessCard(Guid.Parse("11111111-1111-1111-1111-111111111111"));
        var card2 = new AccessCard(Guid.Parse("22222222-2222-2222-2222-222222222222"));
        var card3 = new AccessCard(Guid.Parse("33333333-3333-3333-3333-333333333333"));
        modelBuilder.Entity<AccessCard>().HasData(
            card1,
            card2,
            card3
        );

        return [card1, card2, card3];
    }

    private static List<(Guid Id, Permission Permission)> CreatePermissions(this ModelBuilder modelBuilder)
    {
        var gymPermissionNameResult = PermissionName.Create("Gym");
        var poolPermissionNameResult = PermissionName.Create("Pool");
        var maintenancePermissionNameResult = PermissionName.Create("Maintenance");

        if (gymPermissionNameResult.IsFailure)
        {
            throw new Exception(gymPermissionNameResult.Error.Message);
        }

        if (poolPermissionNameResult.IsFailure)
        {
            throw new Exception(poolPermissionNameResult.Error.Message);
        }

        if (maintenancePermissionNameResult.IsFailure)
        {
            throw new Exception(maintenancePermissionNameResult.Error.Message);
        }

        var gymPermissionDescriptionResult = PermissionDescription.Create("Gym permission");
        var poolPermissionDescriptionResult = PermissionDescription.Create("Pool permission");
        var maintenancePermissionDescriptionResult = PermissionDescription.Create("Maintenance permission");

        if (gymPermissionDescriptionResult.IsFailure)
        {
            throw new Exception(gymPermissionDescriptionResult.Error.Message);
        }

        if (poolPermissionDescriptionResult.IsFailure)
        {
            throw new Exception(poolPermissionDescriptionResult.Error.Message);
        }

        if (maintenancePermissionDescriptionResult.IsFailure)
        {
            throw new Exception(maintenancePermissionDescriptionResult.Error.Message);
        }

        var gymPermission = new Permission(
            "Gym",
            gymPermissionNameResult.Value,
            gymPermissionDescriptionResult.Value
        );

        var poolPermission = new Permission(
            "Pool",
            poolPermissionNameResult.Value,
            poolPermissionDescriptionResult.Value
        );

        var maintenancePermission = new Permission(
            "Maintenance",
            maintenancePermissionNameResult.Value,
            maintenancePermissionDescriptionResult.Value
        );

        var gymPermissionId = Guid.Parse("44444444-4444-4444-4444-444444444444");
        var poolPermissionId = Guid.Parse("55555555-5555-5555-5555-555555555555");
        var maintenancePermissionId = Guid.Parse("66666666-6666-6666-6666-666666666666");
        modelBuilder.Entity<Permission>().HasData(
            new
            {
                Id = gymPermissionId,
                PermissionCodeName = "Gym"
            },
            new
            {
                Id = poolPermissionId,
                PermissionCodeName = "Pool"
            },
            new
            {
                Id = maintenancePermissionId,
                PermissionCodeName = "Maintenance"
            }
        );

        // Seeding owned types
        modelBuilder.Entity<Permission>().OwnsOne(p => p.PermissionName).HasData(
            new
            {
                PermissionId = gymPermissionId,
                gymPermissionNameResult.Value.Value
            },
            new
            {
                PermissionId = poolPermissionId,
                poolPermissionNameResult.Value.Value
            },
            new
            {
                PermissionId = maintenancePermissionId,
                maintenancePermissionNameResult.Value.Value
            }
        );

        modelBuilder.Entity<Permission>().OwnsOne(p => p.PermissionDescription).HasData(
            new
            {
                PermissionId = gymPermissionId,
                gymPermissionDescriptionResult.Value.Value
            },
            new
            {
                PermissionId = poolPermissionId,
                poolPermissionDescriptionResult.Value.Value
            },
            new
            {
                PermissionId = maintenancePermissionId,
                maintenancePermissionDescriptionResult.Value.Value
            }
        );


        return new List<(Guid, Permission)>
        {
            (gymPermissionId, gymPermission),
            (poolPermissionId, poolPermission),
            (maintenancePermissionId, maintenancePermission)
        };
    }

    private static List<(Guid Id, RoleEntity Role)> CreateRoles(this ModelBuilder modelBuilder)
    {
        var receptionistRoleNameResult = RoleName.Create("Receptionist");
        var guestRoleNameResult = RoleName.Create("Guest");

        if (receptionistRoleNameResult.IsFailure)
        {
            throw new Exception(receptionistRoleNameResult.Error.Message);
        }

        if (guestRoleNameResult.IsFailure)
        {
            throw new Exception(guestRoleNameResult.Error.Message);
        }

        var receptionistRoleDescriptionResult = RoleDescription.Create("Receptionist role");
        var guestRoleDescriptionResult = RoleDescription.Create("Guest role");

        if (receptionistRoleDescriptionResult.IsFailure)
        {
            throw new Exception(receptionistRoleDescriptionResult.Error.Message);
        }

        if (guestRoleDescriptionResult.IsFailure)
        {
            throw new Exception(guestRoleDescriptionResult.Error.Message);
        }

        // Create Role objects
        var receptionistRole = new RoleEntity(
            "Receptionist",
            receptionistRoleNameResult.Value,
            receptionistRoleDescriptionResult.Value
        );

        var guestRole = new RoleEntity(
            "Guest",
            guestRoleNameResult.Value,
            guestRoleDescriptionResult.Value
        );


        var receptionistRoleId = Guid.Parse("77777777-7777-7777-7777-777777777777");
        var guestRoleId = Guid.Parse("88888888-8888-8888-8888-888888888888");
        modelBuilder.Entity<RoleEntity>().HasData(
            new
            {
                Id = receptionistRoleId,
                RoleCodeName = "Receptionist"
            },
            new
            {
                Id = guestRoleId,
                RoleCodeName = "Guest"
            }
        );

        // Seeding owned types (RoleName)
        modelBuilder.Entity<RoleEntity>().OwnsOne(r => r.RoleName).HasData(
            new
            {
                RoleId = receptionistRoleId,
                receptionistRoleNameResult.Value.Value
            },
            new
            {
                RoleId = guestRoleId,
                guestRoleDescriptionResult.Value.Value
            }
        );

        // Seeding owned types (RoleDescription)
        modelBuilder.Entity<RoleEntity>().OwnsOne(r => r.RoleDescription).HasData(
            new
            {
                RoleId = receptionistRoleId,
                receptionistRoleDescriptionResult.Value.Value
            },
            new
            {
                RoleId = guestRoleId,
                guestRoleDescriptionResult.Value.Value
            }
        );

        return new List<(Guid, RoleEntity)>
        {
            (receptionistRoleId, receptionistRole),
            (guestRoleId, guestRole)
        };
    }

    public static void AddPermissionsToRoles(this ModelBuilder modelBuilder, List<(Guid Id, RoleEntity Role)> roles,
        List<(Guid Id, Permission Permission)> permissions)
    {
        var receptionistRole = roles.First(r => r.Role.RoleName.Value == "Receptionist");
        var guestRole = roles.First(r => r.Role.RoleName.Value == "Guest");
        var gymPermission = permissions.First(p => p.Permission.PermissionName.Value == "Gym");
        var poolPermission = permissions.First(p => p.Permission.PermissionName.Value == "Pool");

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

    public static void AddRolesToCards(this ModelBuilder modelBuilder, List<(Guid Id, RoleEntity Role)> roles, List<AccessCard> accessCards)
    {
        var receptionistRole = roles.First(r => r.Role.RoleName.Value == "Receptionist");
        var guestRole = roles.First(r => r.Role.RoleName.Value == "Guest");
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

    public static void AddExtraPermissionsToCards(this ModelBuilder modelBuilder, List<(Guid Id, Permission Permission)> permissions, List<AccessCard> accessCards)
    {
        var maintenancePermission = permissions.First(p => p.Permission.PermissionName.Value == "Maintenance");
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