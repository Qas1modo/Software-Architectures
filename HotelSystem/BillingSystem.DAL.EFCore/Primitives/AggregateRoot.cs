using BillingSystem.DAL.EFCore.Entities.Base;

namespace BillingSystem.DAL.EFCore.Primitives;

public abstract class AggregateRoot : BaseEntity
{
    protected AggregateRoot(Guid id)
        : base(id)
    {
    }

    protected AggregateRoot()
    {
    }
}
