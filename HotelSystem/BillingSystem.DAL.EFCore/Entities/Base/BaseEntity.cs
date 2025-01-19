using BillingSystem.DAL.EFCore.Entities.Interfaces.Base;

namespace BillingSystem.DAL.EFCore.Entities.Base;

public class BaseEntity : IBaseEntity
{
    public Guid Id { get; set; }
}
