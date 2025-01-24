namespace HotelServiceSystem.Contracts.Models.Guest;

public class UpdateGuestModel
{
    public Guid GuestId { get; set; }
    public Guid GlobalGuestId { get; set; }
    public string GuestName { get; set; } = null!;
    public int GuestRoom { get; set; }
    public bool Active { get; set; }
}
