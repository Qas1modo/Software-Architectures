using HotelServiceSystem.Domain.Core.Events;
using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Domain.Events.PremiumService;

public class PremiumServiceUpdatedDomainEvent : IDomainEvent
{
    internal PremiumServiceUpdatedDomainEvent(PremiumServiceEntity premiumService) => PremiumService = premiumService;

    public PremiumServiceEntity PremiumService { get; }
}
