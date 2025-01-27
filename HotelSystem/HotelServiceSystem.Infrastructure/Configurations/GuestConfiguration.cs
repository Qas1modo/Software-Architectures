using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelServiceSystem.Infrastructure.Configurations;

/// <summary>
/// Represents the configuration for the <see cref="GuestEntity"/> entity.
/// </summary>
internal sealed class GuestConfiguration : IEntityTypeConfiguration<GuestEntity>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<GuestEntity> builder)
    {
        builder.HasKey(guest => guest.Id);

        builder.Property(guest => guest.GlobalGuestId)
            .IsRequired();

        builder.OwnsOne(guest => guest.GuestFirstName, firstNameBuilder =>
        {
            firstNameBuilder.WithOwner();
            firstNameBuilder.Property(firstName => firstName.Value)
                .HasColumnName(nameof(GuestEntity.GuestFirstName))
                .HasMaxLength(FirstName.MaxLength)
                .IsRequired();
        });

        builder.OwnsOne(guest => guest.GuestLastName, lastNameBuilder =>
        {
            lastNameBuilder.WithOwner();
            lastNameBuilder.Property(lastName => lastName.Value)
                .HasColumnName(nameof(GuestEntity.GuestLastName))
                .HasMaxLength(LastName.MaxLength)
                .IsRequired();
        });

        builder.OwnsOne(guest => guest.GuestRoomNumber, roomNumberBuilder =>
        {
            roomNumberBuilder.WithOwner();
            roomNumberBuilder.Property(roomNumber => roomNumber.Value)
                .HasColumnName(nameof(GuestEntity.GuestRoomNumber))
                .HasMaxLength(RoomNumber.MaxRoom)
                .IsRequired();
        });

        builder.OwnsOne(guest => guest.Email); // Configure Email as a Value Object

        builder.Property(guest => guest.Active)
            .HasDefaultValue(true);

        builder.Property(guest => guest.CreatedOnUtc)
            .HasDefaultValueSql("getutcdate()");

        builder.Property(guest => guest.ModifiedOnUtc);

        builder.Property(guest => guest.DeletedOnUtc);

        builder.Property(guest => guest.Deleted)
            .HasDefaultValue(false);

        builder.HasQueryFilter(guest => !guest.Deleted);
    }
}
