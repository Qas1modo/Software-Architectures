using AccessSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessSystem.Infrastructure.Configurations;

public class AccessClaimPermissionConfiguration : IEntityTypeConfiguration<AccessClaimPermission>
{
    public void Configure(EntityTypeBuilder<AccessClaimPermission> builder)
    {
        builder.HasKey(claim => claim.Id);
        
        builder.HasOne(acp => acp.AccessClaim)
            .WithMany()
            .HasForeignKey(acp => acp.AccessClaimId);

        builder.HasOne(acp => acp.Permission)
            .WithMany()
            .HasForeignKey(acp => acp.PermissionId);
        
        builder.Property(request => request.CreatedOnUtc)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(request => request.ModifiedOnUtc);

        builder.Property(request => request.DeletedOnUtc);

        builder.Property(request => request.Deleted)
            .HasDefaultValue(false);

        builder.HasQueryFilter(request => !request.Deleted);
    }
}