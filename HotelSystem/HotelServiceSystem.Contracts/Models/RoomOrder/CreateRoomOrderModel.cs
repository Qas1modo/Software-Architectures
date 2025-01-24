namespace HotelServiceSystem.Contracts.Models.RoomOrder;

public class CreateRoomOrderModel
{
    public Guid GuestId { get; set; }

    public IEnumerable<Guid> RoomOrderItems { get; set; } = null!;

}
