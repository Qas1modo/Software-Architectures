using AccessSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessSystem.Infrastructure.Configurations;

public class AccessClaimConfiguration : IEntityTypeConfiguration<AccessClaimEntity>
{
    public void Configure(EntityTypeBuilder<AccessClaimEntity> builder)
    {
        builder.HasKey(claim => claim.Id);

        builder.Property(claim => claim.CodeName)
            .IsRequired();
        
        builder.HasMany(claim => claim.AllowedPermissions)
            .WithMany(permission => permission.AccessClaims)
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