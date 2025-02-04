using BillingSystem.Domain.Core;
using ErrorOr;

namespace BillingSystem.Domain.Entities.BillingItem.ValueObjects;

public class UnitPrice : ValueObject
{
    public decimal Value { get; private set; }

    public UnitPrice(decimal value)
    {
        Value = value;
    }

    public static ErrorOr<UnitPrice> Create(decimal value)
    {
        if (value < 0)
            return Error.Validation(BillingItemErrors.UnitPriceCanNotBeZeroOrNegative);

        return new UnitPrice(value);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
