using System.ComponentModel.DataAnnotations;

namespace HotelServiceSystem.Contracts.Models.RoomOrder;

public class CancelRoomOrderModel
{
    [Required]
    public Guid GuestId { get; set; }

    [Required]
    public Guid OrderId { get; set; }
}
