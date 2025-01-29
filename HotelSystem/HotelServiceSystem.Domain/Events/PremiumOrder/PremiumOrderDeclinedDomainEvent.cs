using HotelServiceSystem.Domain.Core.Events;
using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Domain.Events.PremiumOrder;

public class PremiumOrderDeclinedDomainEvent : IDomainEvent
{
    internal PremiumOrderDeclinedDomainEvent(PremiumServiceOrderEntity premiumServiceOrder) => PremiumServiceOrder = premiumServiceOrder;

    public PremiumServiceOrderEntity PremiumServiceOrder { get; }
}
