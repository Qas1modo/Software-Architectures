using AccessSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessSystem.Infrastructure.Configurations;

public class AccessCardPermissionConfiguration : IEntityTypeConfiguration<AccessCardPermission>
{
    public void Configure(EntityTypeBuilder<AccessCardPermission> builder)
    {
        builder.HasKey(acp => acp.Id);
        
        builder.HasOne(acp => acp.AccessCard)
            .WithMany()
            .HasForeignKey(acp => acp.AccessCardId);

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