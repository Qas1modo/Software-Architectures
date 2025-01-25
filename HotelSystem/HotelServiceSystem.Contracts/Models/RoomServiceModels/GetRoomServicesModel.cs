using HotelServiceSystem.Contracts.Enumerations;

namespace HotelServiceSystem.Contracts.Models.RoomServiceModels;

public class GetRoomServicesModel
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
    public OrderByEnum OrderBy { get; set; } = OrderByEnum.DateAdded;
    public bool OrderByDescending { get; set; } = true;
}
