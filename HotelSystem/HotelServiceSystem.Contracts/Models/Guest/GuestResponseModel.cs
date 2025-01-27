namespace HotelServiceSystem.Contracts.Models.Guest;

public class GuestResponseModel
{
    public GuestResponseModel() { }

    public Guid GuestId { get; set; }
    public string GuestFirstName { get; set; } = null!;
    public string GuestLastName { get; set; } = null!;
    public string GuestEmail { get; set; } = null!;
    public int GuestRoomNumber {  get; set; }
    public Guid GlobalGuestId { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }

}
