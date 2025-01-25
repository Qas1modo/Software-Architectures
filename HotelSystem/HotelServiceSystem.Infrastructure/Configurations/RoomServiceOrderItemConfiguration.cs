using HotelServiceSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelServiceSystem.Infrastructure.Configurations
{
    /// <summary>
    /// Represents the configuration for the <see cref="RoomServiceOrderItem"/> entity.
    /// </summary>
    internal sealed class RoomServiceOrderItemConfiguration : IEntityTypeConfiguration<RoomServiceOrderItem>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<RoomServiceOrderItem> builder)
        {
            builder.HasKey(orderItem => orderItem.Id);

            builder.OwnsOne(orderItem => orderItem.UnitPrice, priceBuilder =>
            {
                priceBuilder.WithOwner();
                priceBuilder.Property(price => price.Value)
                    .HasColumnName(nameof(RoomServiceOrderItem.UnitPrice))
                    .HasColumnType("decimal(6,4)")
                    .IsRequired();
            });

            builder.OwnsOne(orderItem => orderItem.Amount, amountBuilder =>
            {
                amountBuilder.WithOwner();
                amountBuilder.Property(amount => amount.Value)
                    .HasColumnName(nameof(RoomServiceOrderItem.Amount))
                    .IsRequired();
            });

            builder.HasOne<RoomServiceOrder>(orderItem => orderItem.RoomServiceOrder)
                .WithMany(order => order.OrderItems)
                .HasForeignKey(orderItem => orderItem.RoomServiceOrderId)
                .IsRequired();

            builder.HasOne<RoomServiceEntity>(orderItem => orderItem.RoomService)
                .WithMany()
                .HasForeignKey(orderItem => orderItem.RoomServiceId)
                .IsRequired();

            builder.Property(orderItem => orderItem.CreatedOnUtc)
                .HasDefaultValueSql("getutcdate()");

            builder.Property(orderItem => orderItem.ModifiedOnUtc);

            builder.Property(orderItem => orderItem.DeletedOnUtc);

            builder.Property(orderItem => orderItem.Deleted)
                .HasDefaultValue(false);

            builder.HasQueryFilter(orderItem => !orderItem.Deleted);
        }
    }
}
