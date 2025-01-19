using HotelServiceSystem.DAL.Entities;
using HotelServiceSystem.DAL.Entities.Base;
using HotelServiceSystem.Shared.Enums;

namespace HotelServiceSystem.DAL.EFCore.Entities;

public class RoomServiceOrderEntity : Entity
{
    public Guid? GuestId { get; set; }
    public GuestEntity? Guest { get; set; }
    public List<RoomServiceOrderItemEntity> OrderItems { get; set; } = null!;
    public OrderStatusEnum OrderStatus { get; set; }
}
