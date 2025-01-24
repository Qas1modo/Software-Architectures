namespace HotelServiceSystem.Contracts.Models.RoomOrder;

public class CancelRoomOrderModel
{
    public Guid GuestId { get; set; }

    public Guid? OrderId { get; set; }
}
