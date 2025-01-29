using HotelServiceSystem.Domain.Core.Events;
using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Domain.Events.PremiumOrder;

public class PremiumOrderCreatedDomainEvent : IDomainEvent
{
    internal PremiumOrderCreatedDomainEvent(PremiumServiceOrderEntity premiumServiceOrder) => PremiumServiceOrder = premiumServiceOrder;

    public PremiumServiceOrderEntity PremiumServiceOrder { get; }
}
