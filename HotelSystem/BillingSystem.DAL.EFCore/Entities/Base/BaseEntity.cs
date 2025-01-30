using BillingSystem.DAL.EFCore.Entities.Interfaces.Base;
using BillingSystem.DAL.EFCore.Utility;

namespace BillingSystem.DAL.EFCore.Entities.Base;

public class BaseEntity : IBaseEntity
{
    protected BaseEntity(Guid id)
        : this()
    {
        Ensure.NotEmpty(id, "The identifier is required.", nameof(id));

        Id = id;
    }

    protected BaseEntity() { }

    public Guid Id { get; set; }
}
