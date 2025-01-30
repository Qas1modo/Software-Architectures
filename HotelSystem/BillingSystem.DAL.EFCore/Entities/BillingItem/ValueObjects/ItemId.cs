using ErrorOr;
using Inventory.Domain.Common;

namespace BillingSystem.Domain.Entities.BillingItem.ValueObjects;

public class ItemId : ValueObject
{
    public int Value { get; private set; }

    public ItemId(int value)
    {
        Value = value;
    }

    public static ErrorOr<ItemId> Create(int value)
    {
        if (value == default)
            return Error.Validation(BillingItemErrors.ItemIdCannotBeDefault);

        return new ItemId(value);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
