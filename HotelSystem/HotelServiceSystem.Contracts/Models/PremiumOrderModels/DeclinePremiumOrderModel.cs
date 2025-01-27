namespace HotelServiceSystem.Contracts.Models.PremiumOrderModels;

public class DeclinePremiumOrderModel
{
    public Guid GuestId { get; set; }
    public Guid PremiumOrderId { get; set; }
    public string Reason { get; set; } = null!;
}
