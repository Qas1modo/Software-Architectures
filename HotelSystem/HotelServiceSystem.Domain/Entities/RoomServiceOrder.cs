using HotelServiceSystem.Contracts.Enumerations;
using HotelServiceSystem.Domain.Core.Abstractions;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Core.Utility;

namespace HotelServiceSystem.Domain.Entities;

public sealed class RoomServiceOrder : AggregateRoot, IAuditableEntity, ISoftDeletableEntity
{
    public RoomServiceOrder(GuestEntity guest) : base(Guid.NewGuid())
    {
        Ensure.NotNull(guest, DomainErrors.RoomServiceOrderErrors.GuestRequired, nameof(guest));
        Ensure.NotEmpty(guest.Id, DomainErrors.RoomServiceOrderErrors.InvalidGuestId, $"{nameof(guest)}{nameof(guest.Id)}");

        GuestId = guest.Id;
        OrderStatus = OrderStatusEnum.New;
    }

    private RoomServiceOrder() { } // Required by EF Core

    public Guid GuestId { get; private set; }
    public GuestEntity Guest { get; private set; } = null!;

    public OrderStatusEnum OrderStatus { get; private set; }

    public List<RoomServiceOrderItem> OrderItems { get; private set; } = null!;


    // Mandatory Fields

    public bool Deleted { get; }
    public DateTime CreatedOnUtc { get; }
    public DateTime? ModifiedOnUtc { get; }
    public DateTime? DeletedOnUtc { get; }

    public Result ChangeStatusToCancelled()
    {
        if (OrderStatus != OrderStatusEnum.New)
        {
            return Result.Failure(DomainErrors.RoomServiceOrderErrors.InvalidStatusChange(OrderStatus, OrderStatusEnum.Cancelled));
        }

        OrderStatus = OrderStatusEnum.Cancelled;
        return Result.Success();
    }

    public Result ChangeStatusToAccepted()
    {
        if (OrderStatus != OrderStatusEnum.New)
        {
            return Result.Failure(DomainErrors.RoomServiceOrderErrors.InvalidStatusChange(OrderStatus, OrderStatusEnum.Accepted));
        }

        OrderStatus = OrderStatusEnum.Accepted;
        return Result.Success();
    }

    public Result ChangeStatusToDeclined()
    {
        if (OrderStatus != OrderStatusEnum.New)
        {
            return Result.Failure(DomainErrors.RoomServiceOrderErrors.InvalidStatusChange(OrderStatus, OrderStatusEnum.Declined));
        }

        OrderStatus = OrderStatusEnum.Declined;
        return Result.Success();
    }

    public Result ChangeStatusToProcessing()
    {
        if (OrderStatus != OrderStatusEnum.Accepted)
        {
            return Result.Failure(DomainErrors.RoomServiceOrderErrors.InvalidStatusChange(OrderStatus, OrderStatusEnum.Processing));
        }

        OrderStatus = OrderStatusEnum.Processing;
        return Result.Success();
    }

    public Result ChangeStatusToFulfilled()
    {
        if (OrderStatus != OrderStatusEnum.Processing)
        {
            return Result.Failure(DomainErrors.RoomServiceOrderErrors.InvalidStatusChange(OrderStatus, OrderStatusEnum.Fulfilled));
        }

        OrderStatus = OrderStatusEnum.Fulfilled;
        return Result.Success();
    }
}
