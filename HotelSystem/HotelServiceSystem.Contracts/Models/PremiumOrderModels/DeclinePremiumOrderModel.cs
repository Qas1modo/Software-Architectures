using System.ComponentModel.DataAnnotations;

namespace HotelServiceSystem.Contracts.Models.PremiumOrderModels;

public class DeclinePremiumOrderModel
{
    [Required]
    public Guid GuestId { get; set; }

    [Required]
    public Guid PremiumOrderId { get; set; }
    public string Reason { get; set; } = null!;
}
