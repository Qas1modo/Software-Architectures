using Inventory.Domain.Common;

namespace BillingSystem.Domain.Entities.Invoice.ValueObjects;

public class PaymentId : ValueObject
{
    public string Value { get; private set; }

    public PaymentId(string value)
    {
        Value = value;
    }

    public static PaymentId Create(string value) => new PaymentId(value);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
