using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelServiceSystem.Infrastructure.Configurations
{
    /// <summary>
    /// Represents the configuration for the <see cref="EmployeeEntity"/> entity.
    /// </summary>
    internal sealed class EmployeeConfiguration : IEntityTypeConfiguration<EmployeeEntity>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
        {
            builder.HasKey(employee => employee.Id);

            builder.OwnsOne(employee => employee.EmployeeFirstName, firstNameBuilder =>
            {
                firstNameBuilder.WithOwner();
                firstNameBuilder.Property(firstName => firstName.Value)
                    .HasColumnName(nameof(EmployeeEntity.EmployeeFirstName))
                    .HasMaxLength(FirstName.MaxLength)
                    .IsRequired();
            });

            builder.OwnsOne(employee => employee.EmployeeLastName, lastNameBuilder =>
            {
                lastNameBuilder.WithOwner();
                lastNameBuilder.Property(lastName => lastName.Value)
                    .HasColumnName(nameof(EmployeeEntity.EmployeeLastName))
                    .HasMaxLength(LastName.MaxLength)
                    .IsRequired();
            });

            builder.Property(employee => employee.EmployeeType)
                .IsRequired();

            builder.Property(employee => employee.CreatedOnUtc)
                .HasDefaultValueSql("getutcdate()");

            builder.Property(employee => employee.ModifiedOnUtc);

            builder.Property(employee => employee.DeletedOnUtc);

            builder.Property(employee => employee.Deleted)
                .HasDefaultValue(false);

            builder.HasQueryFilter(employee => !employee.Deleted);
        }
    }
}
