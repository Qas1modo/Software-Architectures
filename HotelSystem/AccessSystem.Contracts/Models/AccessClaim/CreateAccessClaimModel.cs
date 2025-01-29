namespace AccessSystem.Contracts.Models.AccessClaim;

public class CreateAccessClaimModel
{
    public string Name { get; set; }

    public ICollection<string> PermissionCodeNames { get; set; } = [];
}