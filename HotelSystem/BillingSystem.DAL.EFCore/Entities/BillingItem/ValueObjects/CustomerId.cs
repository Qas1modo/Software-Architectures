using Inventory.Domain.Common;

namespace BillingSystem.Domain.Entities.BillingItem.ValueObjects;

public class CustomerId : ValueObject
{
    public Guid Value { get; private set; }

    public CustomerId(Guid value)
    {
        Value = value;
    }

    public static CustomerId CreateUnique() => new CustomerId(Guid.NewGuid());

    public static CustomerId Create(Guid value) => new CustomerId(value);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
