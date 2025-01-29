using System.ComponentModel.DataAnnotations;

namespace HotelServiceSystem.Contracts.Models.Guest;

public class UpdateGuestModel
{
    [Required]
    public Guid GuestId { get; set; }

    [Required]
    public Guid GlobalGuestId { get; set; }

    [Required]
    public string GuestFirstName { get; set; } = null!;

    [Required]
    public string GuestLastName { get; set; } = null!;

    [Required]
    public int GuestRoom { get; set; }

    [Required]
    public string Email { get; set; } = null!;

    [Required]
    public bool Active { get; set; }
}
