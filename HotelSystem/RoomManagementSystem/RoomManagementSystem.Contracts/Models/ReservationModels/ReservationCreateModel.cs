using RoomManagementSystem.Contracts.Enums;

namespace RoomManagementSystem.Contracts;

public class ReservationCreateModel
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int RoomId { get; set; }
    public ReservationType ReservationType { get; set; }
}
