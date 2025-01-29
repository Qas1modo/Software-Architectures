namespace AccessSystem.Contracts.Models.AccessLogEntry;

public class AccessLogEntryDetailModel
{
    public Guid AccessLogEntryId { get; set; }
    
    public Guid AccessCardId { get; set; }
    public Guid RoomId { get; set; }
    
    public DateTime AccessDateTime { get; set; }
    
    public bool IsEntryAllowed { get; set; }
}