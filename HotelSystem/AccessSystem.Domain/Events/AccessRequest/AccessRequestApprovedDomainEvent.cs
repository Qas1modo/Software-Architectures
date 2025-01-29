using AccessSystem.Contracts.Models.AccessRequest;
using SharedKernel.Domain.Core.Events;

namespace AccessSystem.Domain.Events.AccessRequest;

public class AccessRequestApprovedDomainEvent : IDomainEvent
{
    public AccessRequestApprovedDomainEvent(RequestAccessResponseModel accessResponse) => AccessResponse = accessResponse;
    
    public RequestAccessResponseModel AccessResponse { get; }
}