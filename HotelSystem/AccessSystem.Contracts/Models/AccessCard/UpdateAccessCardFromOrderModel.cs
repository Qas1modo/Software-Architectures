namespace AccessSystem.Contracts.Models.AccessCard;

public class UpdateAccessCardFromOrderModel
{
    public Guid HolderId { get; set; }
    
    public Guid PremiumOrderId { get; set; }

    public string RoleNameToAdd { get; set; }
}