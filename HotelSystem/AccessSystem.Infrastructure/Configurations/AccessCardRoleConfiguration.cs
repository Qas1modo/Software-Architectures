using AccessSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessSystem.Infrastructure.Configurations;

public class AccessCardRoleConfiguration : IEntityTypeConfiguration<AccessCardRole>
{
    public void Configure(EntityTypeBuilder<AccessCardRole> builder)
    {
        builder.HasKey(acr => acr.Id);
        
        builder.HasOne(acr => acr.AccessCard)
            .WithMany()
            .HasForeignKey(acr => acr.AccessCardId);
        
        builder.HasOne(acr => acr.Role)
            .WithMany()
            .HasForeignKey(acr => acr.RoleId);
    }
}