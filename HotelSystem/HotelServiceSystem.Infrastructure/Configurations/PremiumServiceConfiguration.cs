using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelServiceSystem.Infrastructure.Configurations
{
    /// <summary>
    /// Represents the configuration for the <see cref="PremiumService"/> entity.
    /// </summary>
    internal sealed class PremiumServiceConfiguration : IEntityTypeConfiguration<PremiumService>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<PremiumService> builder)
        {
            builder.HasKey(service => service.Id);

            builder.OwnsOne(service => service.Name, nameBuilder =>
            {
                nameBuilder.WithOwner();
                nameBuilder.Property(name => name.Value)
                    .HasColumnName(nameof(PremiumService.Name))
                    .HasMaxLength(ServiceName.MaxLength)
                    .IsRequired();
            });

            builder.OwnsOne(service => service.Description, descriptionBuilder =>
            {
                descriptionBuilder.WithOwner();
                descriptionBuilder.Property(description => description.Value)
                    .HasColumnName(nameof(PremiumService.Description))
                    .HasMaxLength(ServiceImage.MaxLength)
                    .IsRequired();
            });

            builder.OwnsOne(service => service.Image, imageBuilder =>
            {
                imageBuilder.WithOwner();
                imageBuilder.Property(image => image.Value)
                    .HasColumnName(nameof(PremiumService.Image))
                    .HasMaxLength(ServiceImage.MaxLength)
                    .IsRequired();
            });

            builder.OwnsOne(service => service.Price, priceBuilder =>
            {
                priceBuilder.WithOwner();
                priceBuilder.Property(price => price.Value)
                    .HasColumnName(nameof(PremiumService.Price))
                    .HasColumnType("decimal(6,4)")
                    .IsRequired();
            });

            builder.Property(service => service.RelevantRoleCodeName)
                .IsRequired()
                .HasMaxLength(50);

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
