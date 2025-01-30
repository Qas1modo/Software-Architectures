namespace AccessSystem.Contracts.Models.AccessClaim;

public class AccessClaimResponseModel
{
    public Guid Id { get; set; }
    public ICollection<string> AllowedRoles { get; set; } = [];
}