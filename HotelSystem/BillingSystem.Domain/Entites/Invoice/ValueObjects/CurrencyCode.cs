using BillingSystem.Domain.Core;

namespace BillingSystem.Domain.Entities.Invoice.ValueObjects;

public class CurrencyCode : ValueObject
{
    public string Value { get; private set; }

    public CurrencyCode(string value)
    {
        Value = value;
    }

    public static CurrencyCode Create(string value) => new CurrencyCode(value);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
