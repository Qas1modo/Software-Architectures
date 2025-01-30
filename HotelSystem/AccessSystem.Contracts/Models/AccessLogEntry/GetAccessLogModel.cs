using AccessSystem.Contracts.Enumerations;

namespace AccessSystem.Contracts.Models.AccessLogEntry;

public class GetAccessLogModel
{
    public Guid? AccessLogId { get; set; }
    
    public Guid? AccessCardId { get; set; }
    public Guid? RoomId { get; set; }
    
    public DateTime? TimeFrom { get; set; }
    public DateTime? TimeTo { get; set; }
    
    public bool? IsEntryAllowed { get; set; }
    
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
    public OrderByEnum OrderBy { get; set; } = OrderByEnum.DateAdded;
    public bool OrderByDescending { get; set; } = true;
}