namespace AccessSystem.Contracts.Models.Role;

public class RoleResponseModel
{
    public Guid RoleId { get; set; }

    public string RoleCodeName { get; set; }
    public string RoleName { get; set; }
    public string RoleDescription { get; set; }
}