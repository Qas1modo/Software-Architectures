using AccessSystem.Contracts.Models.AccessRequest;
using SharedKernel.Domain.Core.Events;

namespace AccessSystem.Domain.Events.AccessRequest;

public class AccessRequestDeniedDomainEvent : IDomainEvent
{
    public AccessRequestDeniedDomainEvent(RequestAccessResponseModel accessResponse) => AccessResponse = accessResponse;
    
    public RequestAccessResponseModel AccessResponse { get; }
}