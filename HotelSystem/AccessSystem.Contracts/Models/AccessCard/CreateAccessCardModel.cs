namespace AccessSystem.Contracts.Models.AccessCard;

public class CreateAccessCardModel
{
    public ICollection<string> RoleNames { get; set; }
    public ICollection<string> PermissionNames { get; set; }
}