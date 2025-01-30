namespace RoomManagementSystem.Contracts;

public class RoomCreateModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Capacity { get; set; }
    public decimal Price { get; set; }
    public int BedCount { get; set; }
}
