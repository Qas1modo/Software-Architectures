using HotelServiceSystem.DAL.Entities;
using HotelServiceSystem.DAL.Entities.Base;

namespace HotelServiceSystem.DAL.EFCore.Entities;

public class RoomServiceOrderItemEntity : Entity
{
    public decimal UnitPrice { get; set; }   
    public int Amount { get; set; }

    public Guid? OrderId { get; set; }
    public RoomServiceOrderEntity? Order { get; set; }

    public Guid? MenuItemId { get; set; }
    public RoomServiceItemEntity? MenuItem { get; set; }
}
