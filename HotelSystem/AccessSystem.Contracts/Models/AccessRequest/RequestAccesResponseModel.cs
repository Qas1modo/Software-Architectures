namespace AccessSystem.Contracts.Models.AccessRequest;

public class RequestAccessResponseModel
{
  public Guid AccessCardId { get; set; }
  public Guid ClaimId { get; set; }
  public bool IsAccessAllowed { get; set; }
}