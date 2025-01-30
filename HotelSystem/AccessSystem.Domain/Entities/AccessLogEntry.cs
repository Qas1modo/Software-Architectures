using System.ComponentModel.DataAnnotations.Schema;
using AccessSystem.Domain.Events.AccessLog;
using SharedKernel.Domain.Core.Abstractions;
using SharedKernel.Domain.Core.Primitives;

namespace AccessSystem.Domain.Entities;

public class AccessLogEntry : AggregateRoot, IAuditableEntity
{
    public AccessLogEntry(Guid accessCardId, Guid accessClaimId, DateTime entryTime, bool isEntryAllowed) : base(Guid.NewGuid())
    {
        AccessCardId = accessCardId;
        AccessClaimId = accessClaimId;
        CreatedOnUtc = entryTime;
        IsEntryAllowed = isEntryAllowed;
    }

    public AccessLogEntry()
    {
    }

    public Guid AccessCardId { get; set; }

    [ForeignKey(nameof(AccessCardId))]
    public virtual AccessCardEntity? AccessCard { get; set; }

    public Guid AccessClaimId { get; set; }

    public bool IsEntryAllowed { get; }

    public DateTime CreatedOnUtc { get; }

    public DateTime? ModifiedOnUtc { get; }

    public static AccessLogEntry Create(Guid accessCardId, Guid accessClaimId, DateTime entryTime, bool isEntryAllowed)
    {
        var accessLog = new AccessLogEntry(accessCardId, accessClaimId, entryTime, isEntryAllowed);

        accessLog.AddDomainEvent(new AccessLogCreatedDomainEvent(accessLog));
        
        return accessLog;
    }
}