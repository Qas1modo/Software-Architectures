using System.ComponentModel.DataAnnotations;
using SharedKernel.Domain.Core.Abstractions;
using SharedKernel.Domain.Core.Primitives;

namespace AccessSystem.Domain.Entities;

public class RoleEntity : AggregateRoot, IAuditableEntity, ISoftDeletableEntity
{
    // TODO change roleCodeName to value object
    public RoleEntity(string roleCodeName, string roleName, string roleDescription) : base(Guid.NewGuid())
    {
        RoleCodeName = roleCodeName;
        RoleName = roleName;
        RoleDescription = roleDescription;
    }

    public RoleEntity() { } // Required by EF Core

    [Required]
    public string RoleCodeName { get; set; } = null!;
    [Required]
    public string RoleName { get; set; } = null!;
    [Required]
    public string RoleDescription { get; set; } = null!;
    public virtual List<AccessCardEntity> AccessCards { get; set; } = [];
    
    public virtual List<AccessClaimEntity> AccessClaims { get; set; } = [];
    public DateTime CreatedOnUtc { get; }
    public DateTime? ModifiedOnUtc { get; }
    public DateTime? DeletedOnUtc { get; }
    public bool Deleted { get; }
    
    public static RoleEntity Create(string roleCodeName, string roleName, string roleDescription)
    {
        var roleEntity = new RoleEntity(roleCodeName, roleName, roleDescription);
        return roleEntity;
    }
    
    public RoleEntity Update(string roleCodeName, string roleName, string roleDescription)
    {
        RoleCodeName = roleCodeName;
        RoleName = roleName;
        RoleDescription = roleDescription;
        
        return this;
    }
}