using BillingSystem.DAL.EFCore.Entities.Base;
using BillingSystem.DAL.EFCore.Entities.Interfaces;

namespace BillingSystem.DAL.EFCore.Entities;

public class BillingItemEntity : BaseEntity, IAuditableEntity, ISoftDeletableEntity
{
    public Guid CustomerId { get; set; }
    
    public Guid ItemId { get; set; }

    public decimal ItemPrice { get; set; }

    public int Quantity { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public DateTime? ModifiedOnUtc { get; set; }

    public DateTime? DeletedOnUtc { get; set; }

    public bool Deleted { get; set; }
}
