using System.ComponentModel.DataAnnotations;

namespace HotelServiceSystem.Contracts.Models.RoomOrder;

public class RoomOrderItemModel
{
    [Required]
    public Guid RoomServiceId { get; set; }

    [Required]
    public int Amount { get; set; }
}
