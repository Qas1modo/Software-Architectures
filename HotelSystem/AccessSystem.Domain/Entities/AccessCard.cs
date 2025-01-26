using SharedKernel.Domain.Core.Abstractions;
using SharedKernel.Domain.Core.Primitives;

namespace AccessSystem.Domain.Entities;

public class AccessCard : AggregateRoot, IAuditableEntity, ISoftDeletableEntity
{
    public AccessCard() : base(Guid.NewGuid())
    {
        
    }

    // for testing purposes
    public AccessCard(Guid accessCardId) : base(accessCardId)
    {

    }

    public virtual List<Permission> Permissions { get; set; } = [];
    
    public virtual List<RoleEntity> Roles { get; set; } = [];
    
    public virtual List<AccessLogEntry> AccessLogEntries { get; set; } = [];
    
    public DateTime CreatedOnUtc { get; }
    
    public DateTime? ModifiedOnUtc { get; }
    
    public DateTime? DeletedOnUtc { get; }
    
    public bool Deleted { get; }
}