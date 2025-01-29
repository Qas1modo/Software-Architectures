using AccessSystem.Domain.Entities;
using SharedKernel.Domain.Core.Events;

namespace AccessSystem.Domain.Events.AccessLog;

public class AccessLogCreatedDomainEvent : IDomainEvent
{
    internal AccessLogCreatedDomainEvent(AccessLogEntry accessLog) => AccessLogEntry = accessLog;
    
    public AccessLogEntry AccessLogEntry { get; }
}