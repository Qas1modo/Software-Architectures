using HotelServiceSystem.DAL.Entities.Base;

namespace HotelServiceSystem.DAL.EFCore.Entities
{
    public class GuestEntity : Entity
    {
        public Guid GlobalGuestId { get; set; }

        public required string GuestName { get; set; }

        public required int GuestRoom { get; set; }

        public required List<RoomServiceOrderEntity> Orders { get; set; }
    }
}
