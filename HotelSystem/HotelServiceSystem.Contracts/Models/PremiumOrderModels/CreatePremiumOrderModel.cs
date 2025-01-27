using System.ComponentModel.DataAnnotations;

namespace HotelServiceSystem.Contracts.Models.PremiumOrderModels;

public class CreatePremiumOrderModel
{
    [Required]
    public Guid GuestId { get; set; }

    [Required]
    public Guid PremiumServiceId { get; set; }
}
