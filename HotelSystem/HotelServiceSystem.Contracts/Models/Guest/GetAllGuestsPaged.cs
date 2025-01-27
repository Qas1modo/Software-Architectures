namespace HotelServiceSystem.Contracts.Models.Guest;

public class GetAllGuestsPaged
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
    public bool IsDisabled { get; set; } = false;
}
