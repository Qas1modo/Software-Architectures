using HotelServiceSystem.Domain.Core.Abstractions;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives;
using HotelServiceSystem.Domain.Core.Utility;
using HotelServiceSystem.Domain.ValueObjects;

namespace HotelServiceSystem.Domain.Entities;

public sealed class RoomService : AggregateRoot, IAuditableEntity, ISoftDeletableEntity
{
    public RoomService(ServiceName name, ServiceDescription description, ServiceImage image, Price price) : base(Guid.NewGuid())
    {
        Ensure.NotEmpty(name, DomainErrors.RoomServiceErrors.NameRequired, nameof(name));
        Ensure.NotEmpty(description, DomainErrors.RoomServiceErrors.DescriptionRequired, nameof(description));
        Ensure.NotEmpty(image, DomainErrors.RoomServiceErrors.ImageRequired, nameof(image));
        Ensure.NotNull(price, DomainErrors.RoomServiceErrors.InvalidPrice, nameof(price));

        Name = name;
        Description = description;
        Image = image;
        Price = price;
    }

    private RoomService() { } // Required by EF Core

    public ServiceName Name { get; private set; } = null!;
    public ServiceDescription Description { get; private set; } = null!;
    public ServiceImage Image { get; private set; } = null!;
    public Price Price { get; private set; } = null!;

    public List<RoomServiceOrderItem> OrderItems { get; set; } = null!;

    //Mandatory Fields

    public bool Deleted { get; }
    public DateTime CreatedOnUtc { get; }
    public DateTime? ModifiedOnUtc { get; }
    public DateTime? DeletedOnUtc { get; }
}

