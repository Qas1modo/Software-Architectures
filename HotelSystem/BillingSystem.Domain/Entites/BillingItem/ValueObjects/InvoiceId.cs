using BillingSystem.Domain.Core;
using ErrorOr;

namespace BillingSystem.Domain.Entities.BillingItem.ValueObjects;

public class InvoiceId : ValueObject
{
    public Guid Value { get; private set; }

    public InvoiceId(Guid value)
    {
        Value = value;
    }

    public static ErrorOr<InvoiceId> Create(Guid value)
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
