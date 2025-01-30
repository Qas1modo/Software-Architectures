using System.ComponentModel.DataAnnotations;

namespace HotelServiceSystem.Contracts.Models.RoomOrder;

public class CreateRoomOrderModel
{
    [Required]
    public Guid GuestId { get; set; }

    public List<RoomOrderItemModel> RoomOrderItems { get; set; } = null!;

}
