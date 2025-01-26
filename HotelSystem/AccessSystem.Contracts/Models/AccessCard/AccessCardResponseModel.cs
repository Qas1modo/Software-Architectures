namespace AccessSystem.Contracts.Models.AccessCard;

public class AccessCardResponseModel
{
    public Guid Id { get; set; }
    public ICollection<string> RoleNames { get; set; }
    public ICollection<string> PermissionNames { get; set; }
}