using System.Collections;

namespace AccessSystem.Contracts.Models.AccessCard;

public class UpdateAccessCardModel
{
    public Guid? CardId { get; set; }
    
    public Guid? HolderId { get; set; }

    public bool ResetHolder = false;
    
    public ICollection<string> RoleNamesToAdd { get; set; } = [];
    public ICollection<string> RoleNamesToRemove { get; set; } = [];
    
    public ICollection<string> PermissionNamesToAdd { get; set; } = [];
    public ICollection<string> PermissionNamesToRemove { get; set; } = [];
}