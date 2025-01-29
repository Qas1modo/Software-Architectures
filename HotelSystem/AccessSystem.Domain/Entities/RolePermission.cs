using System.ComponentModel.DataAnnotations.Schema;
using SharedKernel.Domain.Core.Abstractions;
using SharedKernel.Domain.Core.Primitives;

namespace AccessSystem.Domain.Entities;

public class RolePermission : AggregateRoot, IAuditableEntity, ISoftDeletableEntity
{
    public RolePermission(Guid roleId, Guid permissionId) : base(Guid.NewGuid())
    {
        RoleId = roleId;
        PermissionId = permissionId;
    }
    
    public RolePermission()
    {
    }
    
    public Guid? RoleId { get; set; }
    
    [ForeignKey(nameof(RoleId))]
    public virtual RoleEntity? Role { get; set; }
    
    public Guid? PermissionId { get; set; }
    
    [ForeignKey(nameof(PermissionId))]
    public virtual PermissionEntity? Permission { get; set; }
    
    public DateTime CreatedOnUtc { get; }
    
    public DateTime? ModifiedOnUtc { get; }
    
    public DateTime? DeletedOnUtc { get; }
    
    public bool Deleted { get; }
}