using HotelServiceSystem.Contracts.Enumerations;
using HotelServiceSystem.Domain.Core.Abstractions;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Core.Utility;
using HotelServiceSystem.Domain.Events.PremiumOrder;

namespace HotelServiceSystem.Domain.Entities;

public sealed class PremiumServiceOrderEntity : AggregateRoot, IAuditableEntity, ISoftDeletableEntity
{
    private PremiumServiceOrderEntity(GuestEntity guest, PremiumServiceEntity premiumServiceEntity) : base(Guid.NewGuid())
    {
        Ensure.NotNull(premiumServiceEntity, DomainErrors.PremiumServiceOrderErrors.PremiumServiceRequired, nameof(premiumServiceEntity));
        Ensure.NotEmpty(premiumServiceEntity.Id, DomainErrors.PremiumServiceOrderErrors.InvalidOrderedPremiumServiceId, $"{nameof(premiumServiceEntity)}{nameof(premiumServiceEntity.Id)}");
        Ensure.NotNull(guest, DomainErrors.PremiumServiceOrderErrors.GuestRequired, nameof(guest));
        Ensure.NotEmpty(guest.Id, DomainErrors.PremiumServiceOrderErrors.InvalidGuestId, $"{nameof(guest)}{nameof(guest.Id)}");

        GuestId = guest.Id;
        PremiumServiceId = premiumServiceEntity.Id;
        OrderStatus = OrderStatusEnum.New;
    }

    private PremiumServiceOrderEntity() { } // Required by EF Core

    public Guid GuestId { get; private set; }
    public GuestEntity Guest { get; private set; } = null!;

    public Guid PremiumServiceId { get; private set; }
    public PremiumServiceEntity PremiumService { get; private set; } = null!;

    public OrderStatusEnum OrderStatus { get; private set; }

    // Mandatory fields
    public DateTime CreatedOnUtc { get; }
    public DateTime? ModifiedOnUtc { get; }
    public DateTime? DeletedOnUtc { get; }
    public bool Deleted { get; }

    public static PremiumServiceOrderEntity Create(GuestEntity guest, PremiumServiceEntity premiumServiceEntity)
    {
        var premiumService = new PremiumServiceOrderEntity(guest, premiumServiceEntity);
        premiumService.AddDomainEvent(new PremiumOrderCreatedDomainEvent(premiumService));
        return premiumService;
    }

    public Result ChangeStatusToDeclined()
    {
        if (OrderStatus != OrderStatusEnum.New)
        {
            return Result.Failure(DomainErrors.PremiumServiceOrderErrors.InvalidStatusChange(OrderStatus, OrderStatusEnum.Declined));
        }
        AddDomainEvent(new PremiumOrderDeclinedDomainEvent(this));
        OrderStatus = OrderStatusEnum.Declined;
        return Result.Success();
    }

    public Result ChangeStatusToFulfilled()
    {
        if (OrderStatus != OrderStatusEnum.New)
        {
            return Result.Failure(DomainErrors.PremiumServiceOrderErrors.InvalidStatusChange(OrderStatus, OrderStatusEnum.Fulfilled));
        }
        AddDomainEvent(new PremiumOrderFulfilledDomainEvent(this));
        OrderStatus = OrderStatusEnum.Fulfilled;
        return Result.Success();
    }

}