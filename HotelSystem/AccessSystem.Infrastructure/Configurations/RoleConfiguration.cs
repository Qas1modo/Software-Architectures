using AccessSystem.Domain.Entities;
using AccessSystem.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessSystem.Infrastructure.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
{
    public void Configure(EntityTypeBuilder<RoleEntity> builder)
    {
        builder.HasKey(role => role.Id);

        builder.Property(request => request.RoleCodeName)
            .IsRequired();

        builder.OwnsOne(role => role.RoleName, roleNameBuilder =>
        {
            roleNameBuilder.WithOwner();
            roleNameBuilder.Property(roleName => roleName.Value)
                .HasColumnName(nameof(RoleEntity.RoleName))
                .HasMaxLength(RoleName.MaxLength)
                .IsRequired();
        });

        builder.OwnsOne(role => role.RoleDescription, roleDescriptionBuilder =>
        {
            roleDescriptionBuilder.WithOwner();
            roleDescriptionBuilder.Property(roleDescription => roleDescription.Value)
                .HasColumnName(nameof(RoleEntity.RoleDescription))
                .HasMaxLength(RoleDescription.MaxLength)
                .IsRequired();
        });

        builder.HasMany(role => role.Permissions)
            .WithMany(permission => permission.Roles)
            .UsingEntity<RolePermission>();

        builder.Property(request => request.CreatedOnUtc)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(request => request.ModifiedOnUtc);

        builder.Property(request => request.DeletedOnUtc);

        builder.Property(request => request.Deleted)
            .HasDefaultValue(false);

        builder.HasQueryFilter(request => !request.Deleted);

    }
}