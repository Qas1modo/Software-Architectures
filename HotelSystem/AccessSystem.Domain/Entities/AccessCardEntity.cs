using AccessSystem.Domain.Events.AccessCard;
using SharedKernel.Domain.Core.Abstractions;
using SharedKernel.Domain.Core.Primitives;

namespace AccessSystem.Domain.Entities;

public class AccessCardEntity : AggregateRoot, IAuditableEntity, ISoftDeletableEntity
{
    public AccessCardEntity() : base(Guid.NewGuid())
    {
        
    }

    // for testing purposes
    public AccessCardEntity(Guid accessCardId, Guid? holderId) : base(accessCardId)
    {
        HolderId = holderId;
    }
    
    public Guid? HolderId { get; set; }

    public virtual List<PermissionEntity> Permissions { get; set; } = [];
    
    public virtual List<RoleEntity> Roles { get; set; } = [];
    
    public virtual List<AccessLogEntry> AccessLogEntries { get; set; } = [];
    
    public DateTime CreatedOnUtc { get; }
    
    public DateTime? ModifiedOnUtc { get; }
    
    public DateTime? DeletedOnUtc { get; }
    
    public bool Deleted { get; }
    
    public static AccessCardEntity Create()
    {
        var accessCard = new AccessCardEntity();
        
        accessCard.AddDomainEvent(new AccessCardCreatedDomainEvent(accessCard));
        
        return accessCard;
    }
}