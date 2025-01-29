namespace AccessSystem.Contracts.Models.AccessClaim;

public class AccessClaimResponseModel
{
    public Guid Id { get; set; }
    public ICollection<string> AllowedPermissions { get; set; } = [];
}