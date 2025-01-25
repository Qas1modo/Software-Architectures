using HotelServiceSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelServiceSystem.Infrastructure.Configurations
{
    /// <summary>
    /// Represents the configuration for the <see cref="PremiumServiceOrderEntity"/> entity.
    /// </summary>
    internal sealed class PremiumServiceOrderConfiguration : IEntityTypeConfiguration<PremiumServiceOrderEntity>
    {
        public void Configure(EntityTypeBuilder<PremiumServiceOrderEntity> builder)
        {
            builder.HasKey(order => order.Id);

            builder.HasOne(order => order.Guest)
                .WithMany()
                .HasForeignKey(order => order.GuestId)
                .IsRequired();

            builder.HasOne(order => order.PremiumService)
                .WithMany()
                .HasForeignKey(order => order.PremiumServiceId)
                .IsRequired();

            builder.Property(order => order.OrderStatus)
                .IsRequired();

            builder.Property(order => order.CreatedOnUtc)
                .HasDefaultValueSql("getutcdate()");

            builder.Property(order => order.ModifiedOnUtc);

            builder.Property(order => order.DeletedOnUtc);

            builder.Property(order => order.Deleted)
                .HasDefaultValue(false);

            builder.HasQueryFilter(order => !order.Deleted);
        }
    }
}