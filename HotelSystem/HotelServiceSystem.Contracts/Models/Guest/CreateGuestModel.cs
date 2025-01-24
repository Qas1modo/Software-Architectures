namespace HotelServiceSystem.Contracts.Models.Guest;

public class CreateGuestModel
{
    public Guid GlobalGuestId { get; set; }
    public string GuestName { get; set; } = null!;
    public int GuestRoom { get; set; }
}
