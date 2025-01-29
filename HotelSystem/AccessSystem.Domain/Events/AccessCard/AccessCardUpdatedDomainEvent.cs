using AccessSystem.Domain.Entities;
using SharedKernel.Domain.Core.Events;

namespace AccessSystem.Domain.Events.AccessCard;

public class AccessCardUpdatedDomainEvent : IDomainEvent
{
    internal AccessCardUpdatedDomainEvent(AccessCardEntity accessCard) => AccessCard = accessCard;
    
    public AccessCardEntity AccessCard { get; }
}