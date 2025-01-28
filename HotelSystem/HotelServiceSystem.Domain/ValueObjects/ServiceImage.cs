using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Core.Primitives;

namespace HotelServiceSystem.Domain.ValueObjects;

public sealed class ServiceImage : ValueObject
{
    public const int MaxLength = 1000;

    private ServiceImage(string value) => Value = value;

    public string Value { get; }

    public static implicit operator string(ServiceImage serviceImage) => serviceImage.Value;

    public static Result<ServiceImage> Create(string serviceImage) =>
        Result.Create(serviceImage, DomainErrors.ServiceImageErrors.NullOrEmpty)
            .Ensure(si => !string.IsNullOrWhiteSpace(si), DomainErrors.ServiceImageErrors.NullOrEmpty)
            .Ensure(si => si.Length <= MaxLength, DomainErrors.ServiceImageErrors.LongerThanAllowed)
            .Map(si => new ServiceImage(si));

    public override string ToString() => Value;

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
