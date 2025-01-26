namespace AccessSystem.Contracts.Models.AccessLogEntry;

public class GetAccessLogModel
{
    public Guid? AccessLogId { get; set; }
    
    public Guid? AccessCardId { get; set; }
    public Guid? RoomId { get; set; }
    
    public Guid? PermissionId { get; set; }
    public string? PermissionCodeName { get; set; }
    
    public Guid? RoleId { get; set; }
    public string? RoleCodeName { get; set; }
    
    public DateTime? TimeFrom { get; set; }
    public DateTime? TimeTo { get; set; }
    
    public bool? IsEntryAllowed { get; set; }
}