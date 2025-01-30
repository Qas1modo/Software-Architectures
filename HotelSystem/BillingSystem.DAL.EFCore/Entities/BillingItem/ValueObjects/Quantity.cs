using ErrorOr;
using Inventory.Domain.Common;

namespace BillingSystem.Domain.Entities.BillingItem.ValueObjects;

public class Quantity : ValueObject
{
    public int Value { get; private set; }

    public Quantity(int value)
    {
        Value = value;
    }

    public static ErrorOr<Quantity> Create(int value)
    {
        if (value < 0)
            return Error.Validation(BillingItemErrors.QuantityAmountCanNotBeZeroOrNegative);

        return new Quantity(value);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
