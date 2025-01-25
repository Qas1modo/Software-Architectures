namespace HotelServiceSystem.Contracts.Models.Guest;

public class UpdateGuestModel
{
    public Guid GuestId { get; set; }
    public Guid GlobalGuestId { get; set; }
    public string GuestFirstName { get; set; } = null!;
    public string GuestLastName { get; set; } = null!;
    public int GuestRoom { get; set; }
    public string Email { get; set; } = null!;
    public bool Active { get; set; }
}
