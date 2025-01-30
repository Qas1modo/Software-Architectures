using AccessSystem.Domain.Entities;
using SharedKernel.Domain.Core.Events;

namespace AccessSystem.Domain.Events.AccessCard;

public class AccessCardCreatedDomainEvent : IDomainEvent
{
    internal AccessCardCreatedDomainEvent(AccessCardEntity accessCard) => AccessCard = accessCard;
    
    public AccessCardEntity AccessCard { get; }
}
