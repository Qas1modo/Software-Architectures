using AccessSystem.Domain.Core.Errors;
using AccessSystem.Domain.Events.Role;
using AccessSystem.Domain.ValueObjects;
using SharedKernel.Domain.Core.Abstractions;
using SharedKernel.Domain.Core.Primitives;
using SharedKernel.Domain.Core.Utility;

namespace AccessSystem.Domain.Entities;

public class RoleEntity : AggregateRoot, IAuditableEntity, ISoftDeletableEntity
{
    // TODO change roleCodeName to value object
    public RoleEntity(string roleCodeName, RoleName roleName, RoleDescription roleDescription) : base(Guid.NewGuid())
    {
        RoleCodeName = roleCodeName;
        Ensure.NotEmpty(roleName, DomainErrors.RoleNameErrors.NullOrEmpty, nameof(roleName));
        Ensure.NotEmpty(roleDescription, DomainErrors.RoleDescriptionErrors.NullOrEmpty, nameof(roleDescription));
        RoleName = roleName;
        RoleDescription = roleDescription;
    }

    public RoleEntity() { } // Required by EF Core

    public string RoleCodeName { get; private set; }
    public RoleName RoleName { get; private set; }
    public RoleDescription RoleDescription { get; private set; }

    public virtual List<Permission> Permissions { get; set; } = [];
    public virtual List<AccessCard> AccessCards { get; set; } = [];

    public DateTime CreatedOnUtc { get; }
    public DateTime? ModifiedOnUtc { get; }
    public DateTime? DeletedOnUtc { get; }
    public bool Deleted { get; }
    
    public static RoleEntity Create(string roleCodeName, RoleName roleName, RoleDescription roleDescription)
    {
        var roleEntity = new RoleEntity(roleCodeName, roleName, roleDescription);
        roleEntity.AddDomainEvent(new RoleCreatedDomainEvent(roleEntity));
        
        return new RoleEntity(roleCodeName, roleName, roleDescription);
    }
    
    public RoleEntity Update(string? roleCodeName, RoleName? roleName, RoleDescription? roleDescription)
    {
        if (roleCodeName is not null)
        {
            RoleCodeName = roleCodeName;
        }

        if (roleName is not null)
        {
            RoleName = roleName;
        }

        if (roleDescription is not null)
        {
            RoleDescription = roleDescription;
        }

        return this;
    }
}