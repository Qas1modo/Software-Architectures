using AccessSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessSystem.Infrastructure.Configurations;

public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.HasKey(rp => rp.Id);
        
        builder.HasOne(rp => rp.Permission)
            .WithMany()
            .HasForeignKey(rp => rp.PermissionId);
        
        builder.HasOne(rp => rp.Role)
            .WithMany()
            .HasForeignKey(rp => rp.RoleId);
        
        builder.Property(request => request.CreatedOnUtc)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(request => request.ModifiedOnUtc);

        builder.Property(request => request.DeletedOnUtc);

        builder.Property(request => request.Deleted)
            .HasDefaultValue(false);

        builder.HasQueryFilter(request => !request.Deleted);
    }
}