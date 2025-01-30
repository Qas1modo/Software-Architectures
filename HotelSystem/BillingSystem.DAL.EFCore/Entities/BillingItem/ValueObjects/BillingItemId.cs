using Inventory.Domain.Common;

namespace BillingSystem.Domain.Entities.BillingItem.ValueObjects;

public class BillingItemId : ValueObject
{
    public int Value { get; private set; }

    public BillingItemId(int value)
    {
        Value = value;
    }

    public static BillingItemId Create(int value) => new BillingItemId(value);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
