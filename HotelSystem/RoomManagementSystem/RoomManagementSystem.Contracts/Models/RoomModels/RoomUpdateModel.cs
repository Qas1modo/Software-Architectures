using RoomManagementSystem.Contracts.Enums;

namespace RoomManagementSystem.Contracts;

public class RoomUpdateModel
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int? Capacity { get; set; }
    public decimal? Price { get; set; }
    public int? BedCount { get; set; }
    public RoomState? RoomState { get; set; }
}
