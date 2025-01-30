using BillingSystem.DAL.EFCore.Entities.Interfaces;

namespace Inventory.Domain.Common;

public abstract class AggregateRoot<EntityId> : Entity<EntityId>, IAuditableEntity, ISoftDeletableEntity where EntityId : notnull
{
    protected AggregateRoot() { }

    protected AggregateRoot(EntityId id) : base(id) { }

    public DateTime? DeletedOnUtc { get; set; }

    public bool Deleted { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public DateTime? ModifiedOnUtc { get; set; }
}
