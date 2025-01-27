using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelServiceSystem.Infrastructure.Configurations
{
    /// <summary>
    /// Represents the configuration for the <see cref="CleanRoomRequestEntity"/> entity.
    /// </summary>
    internal sealed class CleanRoomRequestConfiguration : IEntityTypeConfiguration<CleanRoomRequestEntity>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<CleanRoomRequestEntity> builder)
        {
            builder.HasKey(request => request.Id);

            builder.Property(request => request.Deadline)
                .IsRequired();

            builder.OwnsOne(request => request.RoomNumber, roomNumberBuilder =>
            {
                roomNumberBuilder.WithOwner();
                roomNumberBuilder.Property(roomNumber => roomNumber.Value)
                    .HasColumnName(nameof(CleanRoomRequestEntity.RoomNumber))
                    .HasMaxLength(RoomNumber.MaxRoom)
                    .IsRequired();
            });

            builder.Property(request => request.EmployeeId);
            builder.HasOne<EmployeeEntity>()
                .WithMany()
                .HasForeignKey(request => request.EmployeeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(request => request.Processed)
                .HasDefaultValue(false);

            builder.Property(request => request.CompletedAt);

            builder.Property(request => request.CreatedOnUtc)
                .HasDefaultValueSql("getutcdate()");

            builder.Property(request => request.ModifiedOnUtc);

            builder.Property(request => request.DeletedOnUtc);

            builder.Property(request => request.Deleted)
                .HasDefaultValue(false);

            builder.HasQueryFilter(request => !request.Deleted);
        }
    }
}
