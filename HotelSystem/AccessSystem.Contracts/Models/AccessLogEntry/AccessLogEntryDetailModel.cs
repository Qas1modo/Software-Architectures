namespace AccessSystem.Contracts.Models.AccessLogEntry;

public class AccessLogEntryDetailModel
{
    Guid AccessLogEntryId { get; set; }
    
    Guid AccessCardId { get; set; }
    Guid RoomId { get; set; }
    
    DateTime AccessDateTime { get; set; }
    
    bool IsEntryAllowed { get; set; }
}