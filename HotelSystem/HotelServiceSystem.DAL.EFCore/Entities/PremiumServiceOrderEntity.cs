using HotelServiceSystem.DAL.Entities.Base;
using HotelServiceSystem.Shared.Enums;

namespace HotelServiceSystem.DAL.EFCore.Entities
{
    public class PremiumServiceOrderEntity : Entity
    {
        public Guid? GuestId { get; set; }
        public GuestEntity? Guest { get; set; }
        public Guid? PremiumServiceItemId { get; set; }
        public PremiumServiceItemEntity OrderedPremiumService { get; set; } = null!;
        public OrderStatusEnum OrderStatus { get; set; }
    }
}
