namespace BillingSystem.DAL.EFCore.Entities.Interfaces;

public interface IAuditableEntity
{
    DateTime CreatedOnUtc { get; }

    DateTime? ModifiedOnUtc { get; }
}