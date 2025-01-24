using HotelServiceSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelServiceSystem.Infrastructure.Configurations
{
    /// <summary>
    /// Represents the configuration for the <see cref="RoomServiceOrder"/> entity.
    /// </summary>
    internal sealed class RoomServiceOrderConfiguration : IEntityTypeConfiguration<RoomServiceOrder>
    {
        public void Configure(EntityTypeBuilder<RoomServiceOrder> builder)
        {
            builder.HasKey(order => order.Id);

            builder.HasOne(order => order.Guest)
                .WithMany()
                .HasForeignKey(order => order.GuestId)
                .IsRequired();

            builder.HasMany(order => order.OrderItems)
                .WithOne(orderItem => orderItem.RoomServiceOrder)
                .HasForeignKey(orderItem => orderItem.RoomServiceOrderId)
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
