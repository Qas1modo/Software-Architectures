namespace AccessSystem.Contracts.Models.AccessClaim;

public class UpdateAccessClaimModel
{
    public Guid Id { get; set; }
    public string? Name { get; set; }

    public ICollection<string> RoleCodeNamesToAdd { get; set; } = [];

    public ICollection<string> RoleCodeNamesToRemove { get; set; } = [];
}