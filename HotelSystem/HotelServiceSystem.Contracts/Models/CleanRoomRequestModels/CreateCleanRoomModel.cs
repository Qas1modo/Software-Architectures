using System.ComponentModel.DataAnnotations;

namespace HotelServiceSystem.Contracts.Models.CleanRoomRequestModels;

public class CreateCleanRoomModel
{
    [Required]
    public int RoomNumber { get; set; }
}
