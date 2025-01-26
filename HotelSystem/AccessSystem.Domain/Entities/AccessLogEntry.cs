using System.ComponentModel.DataAnnotations.Schema;
using SharedKernel.Domain.Core.Abstractions;
using SharedKernel.Domain.Core.Primitives;

namespace AccessSystem.Domain.Entities;

public class AccessLogEntry : AggregateRoot, IAuditableEntity, ISoftDeletableEntity
{
    public AccessLogEntry(Guid accessCardId, DateTime entryTime, bool isEntryAllowed) : base(Guid.NewGuid())
    {
        AccessCardId = accessCardId;
        CreatedOnUtc = entryTime;
        IsEntryAllowed = isEntryAllowed;
    }
    
    public AccessLogEntry()
    {
    }
    
    public Guid AccessCardId { get; set; }
    
    [ForeignKey(nameof(AccessCardId))]
    public virtual AccessCard AccessCard { get; set; }
    
    public bool IsEntryAllowed { get; }
    
    public DateTime CreatedOnUtc { get; }
    
    public DateTime? ModifiedOnUtc { get; }
    
    public DateTime? DeletedOnUtc { get; }
    
    public bool Deleted { get; }
}