using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Core.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelServiceSystem.Domain.ValueObjects
{
    public sealed class ServiceName : ValueObject
    {
        public const int MaxLength = 255;

        private ServiceName(string value) => Value = value;

        public string Value { get; }

        public static implicit operator string(ServiceName serviceName) => serviceName.Value;

        public static Result<ServiceName> Create(string serviceName) =>
            Result.Create(serviceName, DomainErrors.ServiceNameErrors.NullOrEmpty)
                .Ensure(sn => !string.IsNullOrWhiteSpace(sn), DomainErrors.ServiceNameErrors.NullOrEmpty)
                .Ensure(sn => sn.Length <= MaxLength, DomainErrors.ServiceNameErrors.LongerThanAllowed)
                .Map(sn => new ServiceName(sn));

        public override string ToString() => Value;

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
