namespace AccessSystem.Contracts.Models.AccessCard;

public class UpdateAccessCardModel
{
    public Guid Id { get; set; }

    public ICollection<string> AddRoleNames { get; set; } = [];
    public ICollection<string> RemoveRoleNames { get; set; } = [];
    
    public ICollection<string> AddPermissionNames { get; set; } = [];
    public ICollection<string> RemovePermissionNames { get; set; } = [];
}