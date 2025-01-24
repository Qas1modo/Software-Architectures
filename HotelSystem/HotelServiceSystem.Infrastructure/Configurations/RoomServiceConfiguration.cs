using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelServiceSystem.Infrastructure.Configurations
{
    /// <summary>
    /// Represents the configuration for the <see cref="RoomService"/> entity.
    /// </summary>
    internal sealed class RoomServiceConfiguration : IEntityTypeConfiguration<RoomService>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<RoomService> builder)
        {
            builder.HasKey(service => service.Id);

            builder.OwnsOne(service => service.Name, nameBuilder =>
            {
                nameBuilder.WithOwner();
                nameBuilder.Property(name => name.Value)
                    .HasColumnName(nameof(RoomService.Name))
                    .HasMaxLength(ServiceName.MaxLength)
                    .IsRequired();
            });

            builder.OwnsOne(service => service.Description, descriptionBuilder =>
            {
                descriptionBuilder.WithOwner();
                descriptionBuilder.Property(description => description.Value)
                    .HasColumnName(nameof(RoomService.Description))
                    .IsRequired();
            });

            builder.OwnsOne(service => service.Image, imageBuilder =>
            {
                imageBuilder.WithOwner();
                imageBuilder.Property(image => image.Value)
                    .HasColumnName(nameof(RoomService.Image))
                    .HasMaxLength(ServiceImage.MaxLength)
                    .IsRequired();
            });

            builder.OwnsOne(service => service.Price, priceBuilder =>
            {
                priceBuilder.WithOwner();
                priceBuilder.Property(price => price.Value)
                    .HasColumnName(nameof(RoomService.Price))
                    .HasColumnType("decimal(6,4)") // Example: Use appropriate decimal type
                    .IsRequired();
            });

            builder.HasMany(service => service.OrderItems)
                .WithOne(orderItem => orderItem.RoomService)
                .HasForeignKey(orderItem => orderItem.RoomServiceId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(service => service.CreatedOnUtc)
                .HasDefaultValueSql("getutcdate()");

            builder.Property(service => service.ModifiedOnUtc);

            builder.Property(service => service.DeletedOnUtc);

            builder.Property(service => service.Deleted)
                .HasDefaultValue(false);

            builder.HasQueryFilter(service => !service.Deleted);
        }
    }
}
