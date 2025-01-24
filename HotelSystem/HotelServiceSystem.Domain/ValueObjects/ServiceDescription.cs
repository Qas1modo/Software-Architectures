using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Core.Primitives;

namespace HotelServiceSystem.Domain.ValueObjects
{
    public sealed class ServiceDescription : ValueObject
    {
        public const int MaxLength = 5000;

        private ServiceDescription(string value) => Value = value;

        public string Value { get; }

        public static implicit operator string(ServiceDescription serviceDescription) => serviceDescription.Value;

        public static Result<ServiceDescription> Create(string serviceDescription) =>
            Result.Create(serviceDescription, DomainErrors.ServiceDescriptionErrors.NullOrEmpty)
                .Ensure(sd => !string.IsNullOrWhiteSpace(sd), DomainErrors.ServiceDescriptionErrors.NullOrEmpty)
                .Ensure(sd => sd.Length <= MaxLength, DomainErrors.ServiceDescriptionErrors.LongerThanAllowed)
                .Map(sd => new ServiceDescription(sd));

        public override string ToString() => Value;

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
