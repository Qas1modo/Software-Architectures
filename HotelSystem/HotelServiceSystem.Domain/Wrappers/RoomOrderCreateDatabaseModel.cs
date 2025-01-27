using HotelServiceSystem.Domain.ValueObjects;

namespace HotelServiceSystem.Domain.Wrappers;

public class RoomOrderCreateDatabaseModel
{
    public Guid RoomServiceId { get; set; }
    public OrderItemAmount Amount { get; set; } = null!;
}
