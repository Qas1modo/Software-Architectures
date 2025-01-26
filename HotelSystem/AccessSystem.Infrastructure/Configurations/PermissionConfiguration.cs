using AccessSystem.Domain.Entities;
using AccessSystem.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessSystem.Infrastructure.Configurations;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.HasKey(permission => permission.Id);

        builder.Property(request => request.PermissionCodeName)
            .IsRequired();

        builder.OwnsOne(permission => permission.PermissionName, permissionNameBuilder =>
        {
            permissionNameBuilder.WithOwner();
            permissionNameBuilder.Property(permissionName => permissionName.Value)
                .HasColumnName(nameof(Permission.PermissionName))
                .HasMaxLength(PermissionName.MaxLength)
                .IsRequired();
        });

        builder.OwnsOne(permission => permission.PermissionDescription, permissionDescriptionBuilder =>
        {
            permissionDescriptionBuilder.WithOwner();
            permissionDescriptionBuilder.Property(permissionDescription => permissionDescription.Value)
                .HasColumnName(nameof(Permission.PermissionDescription))
                .HasMaxLength(PermissionDescription.MaxLength)
                .IsRequired();
        });

        builder.HasMany(permission => permission.Roles)
            .WithMany(role => role.Permissions)
            .UsingEntity<RolePermission>();

        builder.HasMany(permission => permission.AccessCards)
            .WithMany(card => card.Permissions)
            .UsingEntity<AccessCardPermission>();

        builder.Property(request => request.CreatedOnUtc)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(request => request.ModifiedOnUtc);

        builder.Property(request => request.DeletedOnUtc);

        builder.Property(request => request.Deleted)
            .HasDefaultValue(false);

        builder.HasQueryFilter(request => !request.Deleted);
    }
}