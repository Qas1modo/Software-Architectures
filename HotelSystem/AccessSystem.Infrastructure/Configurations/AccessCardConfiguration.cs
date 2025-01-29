using AccessSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessSystem.Infrastructure.Configurations;

public class AccessCardConfiguration : IEntityTypeConfiguration<AccessCardEntity>
{
    public void Configure(EntityTypeBuilder<AccessCardEntity> builder)
    {
        builder.HasKey(card => card.Id);

        builder.HasMany(card => card.Permissions)
            .WithMany(permission => permission.AccessCards)
            .UsingEntity<AccessCardPermission>();

        builder.HasMany(card => card.Roles)
            .WithMany(role => role.AccessCards)
            .UsingEntity<AccessCardRole>();

        builder.Property(request => request.HolderId);

        builder.Property(request => request.CreatedOnUtc)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(request => request.ModifiedOnUtc);

        builder.Property(request => request.DeletedOnUtc);

        builder.Property(request => request.Deleted)
            .HasDefaultValue(false);

        builder.HasQueryFilter(request => !request.Deleted);
    }
}