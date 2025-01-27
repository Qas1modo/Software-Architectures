namespace HotelServiceSystem.Contracts.Models.RoomOrder;

public class CreateRoomOrderModel
{
    public Guid GuestId { get; set; }

    public IEnumerable<RoomOrderItemModel> RoomOrderItems { get; set; } = null!;

}
