using System.ComponentModel.DataAnnotations;

namespace HotelServiceSystem.Contracts.Models.PremiumOrderModels;

public class FulfillPremiumOrderModel
{
    [Required]
    public Guid PremiumOrderId { get; set; }
}
