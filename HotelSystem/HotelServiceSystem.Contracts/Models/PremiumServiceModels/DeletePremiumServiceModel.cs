using System.ComponentModel.DataAnnotations;

namespace HotelServiceSystem.Contracts.Models.PremiumServiceModels;

public class DeletePremiumServiceModel
{
    [Required]
    public Guid PremiumServiceId { get; set; }
}
