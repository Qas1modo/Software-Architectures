using System.ComponentModel.DataAnnotations;

namespace HotelServiceSystem.Contracts.Models.Guest;

public class DeleteGuestModel
{
    [Required]
    public Guid GuestId { get; set; }
}
