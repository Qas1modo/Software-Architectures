namespace HotelServiceSystem.Contracts.Models.RoomOrder;

public class RoomOrderDetailModel
{
    public Guid GuestId { get; set; }
    public List<RoomOrderItemModel> RoomOrderItems { get; set; } = null!;
}
