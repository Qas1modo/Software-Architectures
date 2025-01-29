using AccessSystem.Domain.Entities;
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

        builder.Property(request => request.RoleName)
            .IsRequired();
        
        builder.Property(request => request.RoleDescription)
            .IsRequired();

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