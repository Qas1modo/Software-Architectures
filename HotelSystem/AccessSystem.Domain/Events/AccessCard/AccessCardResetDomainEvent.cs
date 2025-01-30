using AccessSystem.Domain.Entities;
using SharedKernel.Domain.Core.Events;

namespace AccessSystem.Domain.Events.AccessCard;

public class AccessCardResetDomainEvent : IDomainEvent
{
    internal AccessCardResetDomainEvent(AccessCardEntity accessCard) => AccessCard = accessCard;
    
    public AccessCardEntity AccessCard { get; }
}