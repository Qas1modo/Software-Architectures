using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Core.Primitives;

namespace HotelServiceSystem.Domain.ValueObjects;

public sealed class RoomNumber : ValueObject
{
    public const int MaxRoom = 999999;

    private RoomNumber(int value) => Value = value;

    public int Value { get; }

    public static implicit operator int(RoomNumber roomNumber) => roomNumber.Value;

    public static Result<RoomNumber> Create(int roomNumber) =>
        Result.Create(roomNumber, DomainErrors.PriceErrors.NullOrEmpty)
            .Ensure(rn => roomNumber >= 0, DomainErrors.PriceErrors.CannotBeNegative)
            .Ensure(rn => rn <= MaxRoom, DomainErrors.PriceErrors.LargerThanAllowed)
            .Map(rn => new RoomNumber(rn));


    public override string ToString() => Value.ToString();

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
