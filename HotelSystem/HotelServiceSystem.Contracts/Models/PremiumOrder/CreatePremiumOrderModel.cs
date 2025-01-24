namespace HotelServiceSystem.Contracts.Models.PremiumOrder;

public class CreatePremiumOrderModel
{
    public Guid GuestId { get; set; }

    public Guid PremiumItemId { get; set; }
}
