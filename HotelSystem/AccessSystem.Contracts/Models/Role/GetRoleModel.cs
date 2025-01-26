using AccessSystem.Contracts.Enumerations;

namespace AccessSystem.Contracts.Models.Role;

public class GetRoleModel
{
    public Guid? RoleId { get; set; }
    public string? RoleCodeName { get; set; }
   
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
    public OrderByEnum OrderBy { get; set; } = OrderByEnum.DateAdded;
    public bool OrderByDescending { get; set; } = true;
}