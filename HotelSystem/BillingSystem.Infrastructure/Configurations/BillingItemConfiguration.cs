using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BillingSystem.Domain.Entities.BillingItem;

namespace BillingSystem.Domain.Configurations;

internal sealed class BillingItemConfiguration : IEntityTypeConfiguration<BillingItem>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<BillingItem> builder)
    {
        builder.ToTable(nameof(BillingItem) + "s");

        builder.HasKey(billingItem => billingItem.Id);

        builder.OwnsOne(billingItem => billingItem.CustomerId);   
        
        builder.OwnsOne(billingItem => billingItem.InvoiceId); 
        
        builder.OwnsOne(billingItem => billingItem.Quantity); 
        
        builder.OwnsOne(billingItem => billingItem.ItemId); 
        
        builder.OwnsOne(billingItem => billingItem.UnitPrice); 

        builder.Property(billingItem => billingItem.CreatedOnUtc)
            .HasDefaultValueSql("getutcdate()");

        builder.Property(billingItem => billingItem.ModifiedOnUtc);

        builder.Property(billingItem => billingItem.DeletedOnUtc);

        builder.Property(billingItem => billingItem.Deleted)
            .HasDefaultValue(false);

        builder.HasQueryFilter(billingItem => !billingItem.Deleted);
    }
}
