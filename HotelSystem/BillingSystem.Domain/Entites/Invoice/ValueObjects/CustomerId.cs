using BillingSystem.Domain.Core;

namespace BillingSystem.Domain.Entities.Invoice.ValueObjects;

public class CustomerId : ValueObject
{
    public Guid Value { get; private set; }

    public CustomerId(Guid value)
    {
        Value = value;
    }

    public static CustomerId Create(Guid value) => new CustomerId(value);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
