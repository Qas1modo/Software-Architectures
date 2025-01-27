using HotelServiceSystem.Contracts.Enumerations;
using HotelServiceSystem.Domain.Core.Abstractions;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Core.Utility;
using HotelServiceSystem.Domain.Events.RoomOrder;

namespace HotelServiceSystem.Domain.Entities;

public sealed class RoomServiceOrderEntity : AggregateRoot, IAuditableEntity, ISoftDeletableEntity
{
    private RoomServiceOrderEntity(GuestEntity guest) : base(Guid.NewGuid())
    {
        Ensure.NotNull(guest, DomainErrors.RoomServiceOrderErrors.GuestRequired, nameof(guest));
        Ensure.NotEmpty(guest.Id, DomainErrors.RoomServiceOrderErrors.InvalidGuestId, $"{nameof(guest)}{nameof(guest.Id)}");
        GuestId = guest.Id;
        OrderStatus = OrderStatusEnum.New;

    }

    private RoomServiceOrderEntity() { } // Required by EF Core

    public Guid GuestId { get; private set; }
    public GuestEntity Guest { get; private set; } = null!;

    public OrderStatusEnum OrderStatus { get; private set; }

    public List<RoomServiceOrderItemEntity> OrderItems { get; private set; } = null!;


    // Mandatory Fields

    public bool Deleted { get; }
    public DateTime CreatedOnUtc { get; }
    public DateTime? ModifiedOnUtc { get; }
    public DateTime? DeletedOnUtc { get; }

    public static RoomServiceOrderEntity Create(GuestEntity guest)
    {
        var roomOrder = new RoomServiceOrderEntity(guest);
        roomOrder.AddDomainEvent(new RoomServiceOrderCreatedDomainEvent(roomOrder));
        return roomOrder;
    }

    public void AddUpdatedDomainEvent()
    {
        AddDomainEvent(new RoomServiceOrderUpdatedDomainEvent(this));
    }

    public Result ChangeStatusToCancelled()
    {
        if (OrderStatus != OrderStatusEnum.New)
        {
            return Result.Failure(DomainErrors.RoomServiceOrderErrors.InvalidStatusChange(OrderStatus, OrderStatusEnum.Cancelled));
        }
        AddDomainEvent(new RoomServiceOrderCancelledDomainEvent(this));
        OrderStatus = OrderStatusEnum.Cancelled;
        return Result.Success();
    }

    public Result ChangeStatusToAccepted()
    {
        if (OrderStatus != OrderStatusEnum.New)
        {
            return Result.Failure(DomainErrors.RoomServiceOrderErrors.InvalidStatusChange(OrderStatus, OrderStatusEnum.Accepted));
        }
        AddDomainEvent(new RoomServiceOrderAcceptedDomainEvent(this));
        OrderStatus = OrderStatusEnum.Accepted;
        return Result.Success();
    }

    public Result ChangeStatusToDeclined()
    {
        if (OrderStatus != OrderStatusEnum.New)
        {
            return Result.Failure(DomainErrors.RoomServiceOrderErrors.InvalidStatusChange(OrderStatus, OrderStatusEnum.Declined));
        }
        AddDomainEvent(new RoomServiceOrderDeclinedDomainEvent(this));
        OrderStatus = OrderStatusEnum.Declined;
        return Result.Success();
    }

    public Result ChangeStatusToProcessing()
    {
        if (OrderStatus != OrderStatusEnum.Accepted)
        {
            return Result.Failure(DomainErrors.RoomServiceOrderErrors.InvalidStatusChange(OrderStatus, OrderStatusEnum.Processing));
        }
        AddDomainEvent(new RoomServiceOrderProcessingDomainEvent(this));
        OrderStatus = OrderStatusEnum.Processing;
        return Result.Success();
    }

    public Result ChangeStatusToFulfilled()
    {
        if (OrderStatus != OrderStatusEnum.Processing)
        {
            return Result.Failure(DomainErrors.RoomServiceOrderErrors.InvalidStatusChange(OrderStatus, OrderStatusEnum.Fulfilled));
        }
        AddDomainEvent(new RoomServiceOrderFulfilledDomainEvent(this));
        OrderStatus = OrderStatusEnum.Fulfilled;
        return Result.Success();
    }
}
