using HotelServiceSystem.DAL.Entities.Base;

namespace HotelServiceSystem.DAL.EFCore.Entities;

public class RoomServiceItemEntity : Entity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Image { get; set; } = null!;
    public decimal Price { get; set; }
}
