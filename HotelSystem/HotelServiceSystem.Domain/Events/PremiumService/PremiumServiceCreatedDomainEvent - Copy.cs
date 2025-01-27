using HotelServiceSystem.Domain.Core.Events;
using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Domain.Events.PremiumService;

public class PremiumServiceCreatedDomainEvent : IDomainEvent
{
    internal PremiumServiceCreatedDomainEvent(PremiumServiceEntity premiumService) => PremiumService = premiumService;

    public PremiumServiceEntity PremiumService { get; }
}
