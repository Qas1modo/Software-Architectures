using System.ComponentModel.DataAnnotations;

namespace HotelServiceSystem.Contracts.Models.RoomServiceModels;

public class DeleteRoomServiceModel
{
    [Required]
    public Guid PremiumServiceId { get; set; }
}
