namespace BillingSystem.DAL.EFCore.Entities.Interfaces;

public interface ISoftDeletableEntity
{
    DateTime? DeletedOnUtc { get; }

    bool Deleted { get; }
}
