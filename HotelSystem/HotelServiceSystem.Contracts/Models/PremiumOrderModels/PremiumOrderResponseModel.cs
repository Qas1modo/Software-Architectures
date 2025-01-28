using HotelServiceSystem.Contracts.Enumerations;

namespace HotelServiceSystem.Contracts.Models.PremiumOrderModels;

public class PremiumOrderResponseModel
{
    public Guid OrderId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Image { get; set; } = null!;
    public decimal Price { get; set; }
    public OrderStatusEnum OrderStatus { get; set; }
    public DateTime CreatedOnUtc { get; set; }
}
