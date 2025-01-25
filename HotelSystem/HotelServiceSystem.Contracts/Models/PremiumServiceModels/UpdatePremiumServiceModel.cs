namespace HotelServiceSystem.Contracts.Models.PremiumServiceModels;

public class UpdatePremiumServiceModel
{
    public Guid PremiumServiceId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Image { get; set; } = null!;
    public decimal Price { get; set; }
    public string RelevantRoleCodeName { get; set; } = null!;
}
