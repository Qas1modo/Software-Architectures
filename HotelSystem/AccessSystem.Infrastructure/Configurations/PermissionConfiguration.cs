using AccessSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessSystem.Infrastructure.Configurations;

public class PermissionConfiguration : IEntityTypeConfiguration<PermissionEntity>
{
    public void Configure(EntityTypeBuilder<PermissionEntity> builder)
    {
        builder.HasKey(permission => permission.Id);

        builder.Property(request => request.PermissionCodeName)
            .IsRequired();

        builder.Property(request => request.PermissionName)
            .IsRequired();
        
        builder.Property(request => request.PermissionDescription)
            .IsRequired();

        builder.HasMany(permission => permission.Roles)
            .WithMany(role => role.Permissions)
            .UsingEntity<RolePermission>();

        builder.HasMany(permission => permission.AccessCards)
            .WithMany(card => card.Permissions)
            .UsingEntity<AccessCardPermission>();
        
        builder.HasMany(permission => permission.AccessClaims)
            .WithMany(claim => claim.AllowedPermissions)
            .UsingEntity<AccessClaimPermission>();

        builder.Property(request => request.CreatedOnUtc)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(request => request.ModifiedOnUtc);

        builder.Property(request => request.DeletedOnUtc);

        builder.Property(request => request.Deleted)
            .HasDefaultValue(false);

        builder.HasQueryFilter(request => !request.Deleted);
    }
}