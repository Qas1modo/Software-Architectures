using AccessSystem.Contracts.Enumerations;

namespace AccessSystem.Contracts.Models.Permission;

public class GetPermissionModel
{
    public Guid? PermissionId { get; set; }
    public string? PermissionCodeName { get; set; }
}