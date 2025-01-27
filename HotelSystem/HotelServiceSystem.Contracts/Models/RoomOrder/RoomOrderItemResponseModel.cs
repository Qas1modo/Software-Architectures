namespace HotelServiceSystem.Contracts.Models.RoomOrder;

public class RoomOrderItemResponseModel
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Image { get; set; } = null!;
    public decimal UnitPrice { get; set; }
    public int Amount { get; set; }
}
