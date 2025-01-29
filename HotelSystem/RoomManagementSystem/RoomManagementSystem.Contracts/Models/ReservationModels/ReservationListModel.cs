using RoomManagementSystem.Contracts.Enums;

namespace RoomManagementSystem.Contracts;

public class ReservationListModel
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int RoomId { get; set; }
    public ReservationType ReservationType { get; set; }
    public ReservationState State { get; set; }
}
