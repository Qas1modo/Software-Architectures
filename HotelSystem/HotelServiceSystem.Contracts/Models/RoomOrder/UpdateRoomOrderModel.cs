namespace HotelServiceSystem.Contracts.Models.RoomOrder;

public class UpdateRoomOrderModel
{
    public Guid GuestId { get; set; }
    public Guid? OrderId { get; set; }
    public IEnumerable<Guid> ItemsToAdd { get; set; } = null!;
    public IEnumerable<Guid> ItemsToDelete { get; set; } = null!;
}
