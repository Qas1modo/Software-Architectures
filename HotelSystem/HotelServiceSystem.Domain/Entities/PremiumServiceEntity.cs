using HotelServiceSystem.Domain.Core.Abstractions;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives;
using HotelServiceSystem.Domain.Core.Utility;
using HotelServiceSystem.Domain.Events.PremiumService;
using HotelServiceSystem.Domain.ValueObjects;

namespace HotelServiceSystem.Domain.Entities;

public sealed class PremiumServiceEntity : AggregateRoot, IAuditableEntity, ISoftDeletableEntity
{
    private PremiumServiceEntity(ServiceName name, ServiceDescription description, ServiceImage image, Price price, string relevantRoleCodeName) : base(Guid.NewGuid())
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

    private PremiumServiceEntity() { } // Required by EF Core

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

    public static PremiumServiceEntity Create(ServiceName name, ServiceDescription description, ServiceImage image, Price price, string relevantRoleCodeName)
    {
        var premiumService = new PremiumServiceEntity(name, description, image, price, relevantRoleCodeName);
        premiumService.AddDomainEvent(new PremiumServiceCreatedDomainEvent(premiumService));
        return premiumService;
    }

    public PremiumServiceEntity Update(ServiceName name, ServiceDescription description,
        ServiceImage image, Price price, string relevantRoleCodeName)
    {
        Price = price;
        Description = description;
        Image = image;
        Name = name;
        RelevantRoleCodeName = relevantRoleCodeName;
        AddDomainEvent(new PremiumServiceUpdatedDomainEvent(this));
        return this;
    }
}
