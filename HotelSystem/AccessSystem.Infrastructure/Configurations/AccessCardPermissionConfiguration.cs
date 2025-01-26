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
    }
}