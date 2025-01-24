using HotelServiceSystem.Domain.Core.Abstractions;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives;
using HotelServiceSystem.Domain.Core.Utility;
using HotelServiceSystem.Domain.ValueObjects;

namespace HotelServiceSystem.Domain.Entities
{
    public sealed class PremiumService : AggregateRoot, IAuditableEntity, ISoftDeletableEntity
    {
        public PremiumService(ServiceName name, ServiceDescription description, ServiceImage image, Price price, string relevantRoleCodeName) : base(Guid.NewGuid())
        {
            Ensure.NotEmpty(name, DomainErrors.PremiumServiceErrors.NameRequired, nameof(name));
            Ensure.NotEmpty(description, DomainErrors.PremiumServiceErrors.DescriptionRequired, nameof(description));
            Ensure.NotEmpty(image, DomainErrors.PremiumServiceErrors.ImageRequired, nameof(image));
            Ensure.NotNull(price, DomainErrors.PremiumServiceErrors.InvalidPrice, nameof(price));
            Ensure.NotEmpty(relevantRoleCodeName, DomainErrors.PremiumServiceErrors.RelevantRoleCodeNameRequired, nameof(relevantRoleCodeName));

            Name = name;
            Description = description;
            Image = image;
            Price = price;
            RelevantRoleCodeName = relevantRoleCodeName;
        }

        private PremiumService() { } // Required by EF Core

        public ServiceName Name { get; private set; } = null!;
        public ServiceDescription Description { get; private set; } = null!;
        public ServiceImage Image { get; private set; } = null!;
        public Price Price { get; private set; } = null!;
        public string RelevantRoleCodeName { get; private set; } = null!;

        // Mandatory fields
        public DateTime CreatedOnUtc { get; }
        public DateTime? ModifiedOnUtc { get; }
        public DateTime? DeletedOnUtc { get; }
        public bool Deleted { get; }


    }

}
