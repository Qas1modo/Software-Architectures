using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Core.Primitives;

namespace HotelServiceSystem.Domain.ValueObjects;

public sealed class OrderItemAmount : ValueObject
{
    public const int MaxOrderItemCount = 9;

    private OrderItemAmount(int value) => Value = value;

    public int Value { get; }

    public static implicit operator int(OrderItemAmount orderItemAmount) => orderItemAmount.Value;

    public static Result<OrderItemAmount> Create(int orderItemAmount) =>
        Result.Create(orderItemAmount, DomainErrors.OrderItemAmountErrors.NullOrEmpty)
            .Ensure(oia => orderItemAmount > 0, DomainErrors.OrderItemAmountErrors.CannotBeNegative)
            .Ensure(oia => oia <= MaxOrderItemCount, DomainErrors.OrderItemAmountErrors.LargerThanAllowed)
            .Map(oia => new OrderItemAmount(oia));


    public override string ToString() => Value.ToString();

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
