using System.ComponentModel.DataAnnotations;

namespace HotelServiceSystem.Contracts.Models.PremiumServiceModels;

public class CreatePremiumServiceModel
{
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    [Required]
    public string Image { get; set; } = null!;

    [Required]
    public decimal Price { get; set; }

    [Required]
    public string RelevantRoleCodeName { get; set; } = null!;
}
