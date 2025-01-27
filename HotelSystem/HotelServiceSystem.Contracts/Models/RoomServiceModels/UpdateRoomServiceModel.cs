using System.ComponentModel.DataAnnotations;

namespace HotelServiceSystem.Contracts.Models.RoomServiceModels;

public class UpdateRoomServiceModel
{
    [Required]
    public Guid PremiumServiceId { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    [Required]
    public string Image { get; set; } = null!;

    [Required]
    public decimal Price { get; set; }
}
