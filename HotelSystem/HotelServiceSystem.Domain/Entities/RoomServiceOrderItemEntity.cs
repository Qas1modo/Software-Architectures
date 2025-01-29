using HotelServiceSystem.Domain.Core.Abstractions;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives;
using HotelServiceSystem.Domain.Core.Utility;
using HotelServiceSystem.Domain.ValueObjects;

namespace HotelServiceSystem.Domain.Entities;

public sealed class RoomServiceOrderItemEntity : Entity, IAuditableEntity, ISoftDeletableEntity
{
    public RoomServiceOrderItemEntity(Price unitPrice, OrderItemAmount amount, RoomServiceEntity roomService, RoomServiceOrderEntity order) : base(Guid.NewGuid())
    {
        Ensure.NotNull(unitPrice, DomainErrors.RoomServiceOrderItemErrors.InvalidUnitPrice, nameof(unitPrice));
        Ensure.NotNull(amount, DomainErrors.RoomServiceOrderItemErrors.InvalidAmount, nameof(amount));
        Ensure.NotNull(roomService, DomainErrors.RoomServiceOrderItemErrors.RoomServiceRequired, nameof(roomService));
        Ensure.NotEmpty(roomService.Id, DomainErrors.RoomServiceOrderItemErrors.InvalidRoomServiceId, $"{nameof(roomService)}{nameof(roomService.Id)}");
        Ensure.NotNull(order, DomainErrors.RoomServiceOrderItemErrors.RoomServiceOrderRequired, nameof(order));
        Ensure.NotEmpty(order.Id, DomainErrors.RoomServiceOrderItemErrors.InvalidRoomServiceOrderId, $"{nameof(order)}{nameof(order.Id)}");
        UnitPrice = unitPrice;
        Amount = amount;
        RoomServiceId = roomService.Id;
        RoomServiceOrderId = order.Id;
        CreatedOnUtc = DateTime.UtcNow;
    }

    private RoomServiceOrderItemEntity() { } // Required by EF Core

    public Price UnitPrice { get; private set; } = null!;
    public OrderItemAmount Amount { get; private set; } = null!;
    public Guid RoomServiceOrderId { get; private set; }
    public RoomServiceOrderEntity RoomServiceOrder { get; private set; } = null!;

    public Guid RoomServiceId { get; private set; }
    public RoomServiceEntity RoomService { get; private set; } = null!;


    // Mandatory Fields

    public DateTime CreatedOnUtc { get; }
    public DateTime? ModifiedOnUtc { get; }
    public DateTime? DeletedOnUtc { get; }
    public bool Deleted { get; }

    public static RoomServiceOrderItemEntity Create(Price unitPrice, OrderItemAmount amount, 
        RoomServiceEntity roomService, RoomServiceOrderEntity order)
    {
        return new RoomServiceOrderItemEntity(unitPrice, amount, roomService, order);
    }

    public RoomServiceOrderItemEntity ChangeAmount(OrderItemAmount newAmount)
    {
        Amount = newAmount;
        return this;
    }
}
