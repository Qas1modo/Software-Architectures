using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Core.Primitives;

namespace HotelServiceSystem.Domain.ValueObjects
{
    public sealed class Price : ValueObject
    {
        public const decimal MaxPrice = 999999m;

        private Price(decimal value) => Value = value;

        public decimal Value { get; }

        public static implicit operator decimal(Price price) => price.Value;

        public static Result<Price> Create(decimal price) =>
            Result.Create(price, DomainErrors.PriceErrors.NullOrEmpty)
                .Ensure(p => price >= 0m, DomainErrors.PriceErrors.CannotBeNegative)
                .Ensure(p => p <= MaxPrice, DomainErrors.PriceErrors.LargerThanAllowed)
                .Map(p => new Price(p));


        public override string ToString() => Value.ToString();

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
