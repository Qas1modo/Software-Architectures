namespace HotelServiceSystem.Contracts.Models.RoomService;
public class CreateRoomServiceModel
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Image { get; set; } = null!;
    public decimal Price { get; set; }
}
