namespace HotelServiceSystem.Contracts.Models.RoomServiceModels;

public class RoomServiceResponseModel
{
    public Guid RoomServiceId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Image { get; set; } = null!;
    public decimal Price { get; set; }
}
