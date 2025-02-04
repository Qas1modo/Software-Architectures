using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BillingSystem.Domain.Entities.Invoice;

namespace BillingSystem.Domain.Configurations;

internal sealed class InvoiceConfiguration : IEntityTypeConfiguration<InvoiceEntity>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<InvoiceEntity> builder)
    {
        builder.ToTable(InvoiceEntity.TableName);

        builder.HasKey(invoice => invoice.Id);

        builder.OwnsOne(invoice => invoice.FinalPrice);

        builder.OwnsOne(invoice => invoice.CurrencyCode);

        builder.OwnsOne(invoice => invoice.PaymentId);

        builder.OwnsOne(invoice => invoice.IsPaid);

        builder.OwnsOne(invoice => invoice.CustomerId);

        builder.Property(invoice => invoice.CreatedOnUtc)
            .HasDefaultValueSql("getutcdate()");

        builder.Property(invoice => invoice.ModifiedOnUtc);

        builder.Property(invoice => invoice.DeletedOnUtc);

        builder.Property(invoice => invoice.Deleted)
            .HasDefaultValue(false);

        builder.HasQueryFilter(invoice => !invoice.Deleted);
    }
}
