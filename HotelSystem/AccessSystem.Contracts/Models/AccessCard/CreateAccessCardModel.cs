namespace AccessSystem.Contracts.Models.AccessCard;

public class CreateAccessCardModel
{
    public Guid? HolderId { get; set; }
    public ICollection<string> RoleNames { get; set; } = [];
    public ICollection<string> PermissionNames { get; set; } = [];
}