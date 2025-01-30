using ErrorOr;
using Inventory.Domain.Common;

namespace BillingSystem.Domain.Entities.BillingItem.ValueObjects;

public class InvoiceId : ValueObject
{
    public int Value { get; private set; }

    public InvoiceId(int value)
    {
        Value = value;
    }

    public static ErrorOr<InvoiceId> Create(int value)
    {
        if (value == default)
            return Error.Validation(BillingItemErrors.InvoiceIdCannotBeDefault);

        return new InvoiceId(value);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
