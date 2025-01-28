using HotelServiceSystem.Domain.Core.Events;
using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Domain.Events.PremiumOrder;

public class PremiumOrderFulfilledDomainEvent : IDomainEvent
{
    internal PremiumOrderFulfilledDomainEvent(PremiumServiceOrderEntity premiumServiceOrder) => PremiumServiceOrder = premiumServiceOrder;

    public PremiumServiceOrderEntity PremiumServiceOrder { get; }
}
