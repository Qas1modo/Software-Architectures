namespace HotelServiceSystem.Contracts.Models.Guest;

public class CreateGuestModel
{
    public Guid GlobalGuestId { get; set; }
    public string GuestFirstName { get; set; } = null!;
    public string GuestLastName { get; set; } = null!;
    public int GuestRoom { get; set; }
    public string Email { get; set; } = null!;
}
