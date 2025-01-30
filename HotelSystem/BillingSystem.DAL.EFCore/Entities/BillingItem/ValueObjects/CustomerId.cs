using ErrorOr;
using Inventory.Domain.Common;

namespace BillingSystem.Domain.Entities.BillingItem.ValueObjects;

public class CustomerId : ValueObject
{
    public int Value { get; private set; }

    public CustomerId(int value)
    {
        Value = value;
    }

    public static CustomerId Create(int value) => new CustomerId(value);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
