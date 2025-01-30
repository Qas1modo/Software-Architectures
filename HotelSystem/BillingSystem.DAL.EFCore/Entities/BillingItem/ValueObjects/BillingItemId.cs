using Inventory.Domain.Common;

namespace BillingSystem.Domain.Entities.BillingItem.ValueObjects;

public class BillingItemId : ValueObject
{
    public Guid Value { get; private set; }

    public BillingItemId(Guid value)
    {
        Value = value;
    }

    public static BillingItemId Create(Guid value) => new BillingItemId(value);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
