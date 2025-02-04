using BillingSystem.Domain.Core;

namespace BillingSystem.Domain.Entities.Invoice.ValueObjects;

public class IsPaid : ValueObject
{
    public bool Value { get; private set; }

    public IsPaid(bool value)
    {
        Value = value;
    }

    public static IsPaid Create(bool value) => new IsPaid(value);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
