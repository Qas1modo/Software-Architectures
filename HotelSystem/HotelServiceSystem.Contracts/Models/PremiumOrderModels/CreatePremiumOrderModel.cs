namespace HotelServiceSystem.Contracts.Models.PremiumOrderModels;

public class CreatePremiumOrderModel
{
    public Guid GuestId { get; set; }

    public Guid PremiumServiceId { get; set; }
}
