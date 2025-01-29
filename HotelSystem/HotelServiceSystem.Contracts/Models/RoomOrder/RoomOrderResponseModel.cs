namespace HotelServiceSystem.Contracts.Models.RoomOrder;

public class RoomOrderResponseModel
{
    public Guid RoomOrderId { get; set; }
    public DateTime CreatedOnUtc { get; set;  }
    public List<RoomOrderItemResponseModel> OrderItems { get; set; } = null!;

}
