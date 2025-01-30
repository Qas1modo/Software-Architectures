using Inventory.Domain.Common;

namespace BillingSystem.Domain.Entities.Invoice.ValueObjects;

public class FinalPrice : ValueObject
{
    public decimal Value { get; private set; }

    public FinalPrice(decimal value)
    {
        Value = value;
    }

    public static FinalPrice Create(decimal value) => new FinalPrice(value);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
