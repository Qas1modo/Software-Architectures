using BillingSystem.DAL.EFCore.Entities.Base;
using BillingSystem.DAL.EFCore.Entities.Interfaces;

namespace BillingSystem.DAL.EFCore.Entities;

public class InvoiceEntity : BaseEntity, IAuditableEntity, ISoftDeletableEntity
{
    public IEnumerable<BillingItemEntity> OrderedItems { get; set; }

    public decimal FinalPrice { get; set; }

    public string CurrencyCode { get; set; }

    public string PaymentId { get; set; }

    public bool IsPaid { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public DateTime? ModifiedOnUtc { get; set; }

    public DateTime? DeletedOnUtc { get; set; }

    public bool Deleted { get; set; }
}
