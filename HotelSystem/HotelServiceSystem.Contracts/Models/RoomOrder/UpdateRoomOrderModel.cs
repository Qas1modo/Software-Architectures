namespace HotelServiceSystem.Contracts.Models.RoomOrder;

public class UpdateRoomOrderModel
{
    public Guid GuestId { get; set; }
    public Guid OrderId { get; set; }
    public IEnumerable<RoomOrderItemModel> ItemsToAdd { get; set; } = null!;
    public IEnumerable<RoomOrderItemModel> ItemsToDelete { get; set; } = null!;
}
