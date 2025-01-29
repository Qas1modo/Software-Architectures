using System.Collections;

namespace AccessSystem.Contracts.Models.Role;

public class UpdateRoleModel
{
    public Guid RoleId { get; set; }
    
    public string? RoleCodeName { get; set; }
    public string? RoleName { get; set; }
    public string? RoleDescription { get; set; }
    
    public ICollection<string> PermissionCodeNamesToAdd { get; set; } = [];
    
    public ICollection<string> PermissionCodeNamesToRemove{ get; set; } = [];
}