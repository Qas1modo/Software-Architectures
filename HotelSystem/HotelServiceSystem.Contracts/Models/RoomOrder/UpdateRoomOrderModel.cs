using System.ComponentModel.DataAnnotations;

namespace HotelServiceSystem.Contracts.Models.RoomOrder;

public class UpdateRoomOrderModel
{
    [Required]
    public Guid GuestId { get; set; }

    [Required]
    public Guid OrderId { get; set; }

    public IEnumerable<RoomOrderItemModel> ItemsToAdd { get; set; } = [];
    public IEnumerable<RoomOrderItemModel> ItemsToDelete { get; set; } = [];
}
