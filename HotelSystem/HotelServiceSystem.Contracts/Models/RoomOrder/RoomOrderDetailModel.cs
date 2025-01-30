using System.ComponentModel.DataAnnotations;

namespace HotelServiceSystem.Contracts.Models.RoomOrder;

public class RoomOrderDetailModel
{
    [Required]
    public Guid GuestId { get; set; }
    public List<RoomOrderItemModel> RoomOrderItems { get; set; } = null!;
}
