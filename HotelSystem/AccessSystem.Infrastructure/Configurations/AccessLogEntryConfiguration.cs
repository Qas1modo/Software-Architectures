using AccessSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessSystem.Infrastructure.Configurations;

public class AccessLogEntryConfiguration : IEntityTypeConfiguration<AccessLogEntry>
{
    public void Configure(EntityTypeBuilder<AccessLogEntry> builder)
    {
        builder.HasKey(entry => entry.Id);

        builder.Property(entry => entry.AccessCardId)
            .IsRequired();

        builder.Property(entry => entry.IsEntryAllowed)
            .IsRequired();

        builder.HasOne(entry => entry.AccessCard)
            .WithMany(card => card.AccessLogEntries)
            .HasForeignKey(entry => entry.AccessCardId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(request => request.CreatedOnUtc)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(request => request.ModifiedOnUtc);
    }
}