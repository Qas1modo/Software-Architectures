using Inventory.Domain.Common;

namespace BillingSystem.Domain.Entities.Invoice.ValueObjects;

public class InvoiceId : ValueObject
{
    public Guid Value { get; private set; }

    public InvoiceId(Guid value)
    {
        Value = value;
    }

    public static InvoiceId Create(Guid value) => new InvoiceId(value);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
