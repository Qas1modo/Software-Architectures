namespace HotelServiceSystem.Contracts.Models.CleanRoomRequestModels;

public class GetAllNotCompletedCleanRequestsPagedModel
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}
