namespace HotelServiceSystem.Contracts.Models.CleanRoomRequestModels;

public class CleanRoomRequestResponseModel
{
    public Guid CleanRoomRequestGuid { get; set; }

    public DateTime Deadline { get; set; }

    public int RoomNumber { get; set; }
}
