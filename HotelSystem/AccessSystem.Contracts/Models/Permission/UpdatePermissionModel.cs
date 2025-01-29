namespace AccessSystem.Contracts.Models.Permission;

public class UpdatePermissionModel
{
    public Guid PermissionId { get; set; }
    public string PermissionCodeName { get; set; }
    public string PermissionName { get; set; }
    public string PermissionDescription { get; set; }
}