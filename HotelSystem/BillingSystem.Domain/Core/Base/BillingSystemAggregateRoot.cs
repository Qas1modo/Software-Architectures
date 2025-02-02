using SharedKernel.Domain.Core.Abstractions;
using SharedKernel.Domain.Core.Primitives;

namespace BillingSystem.Domain.Core;

public abstract class BillingSystemAggregateRoot : AggregateRoot, IAuditableEntity, ISoftDeletableEntity
{
    protected BillingSystemAggregateRoot() { }

    protected BillingSystemAggregateRoot(Guid id)
    : base(id)
    {
    }

    public DateTime? DeletedOnUtc { get; set; }

    public bool Deleted { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public DateTime? ModifiedOnUtc { get; set; }
}
