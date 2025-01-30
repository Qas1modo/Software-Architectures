using AccessSystem.Contracts.Models.AccessLogEntry;
using AccessSystem.Domain.Entities;
using SharedKernel.Contracts.Models.Core;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace AccessSystem.Domain.Repositories;

public interface IAccessLogEntryRepository
{
    Task<Maybe<AccessLogEntry>> GetByIdAsync(Guid id);
    
    Task<Maybe<PagedList<AccessLogEntryDetailModel>>> GetLogEntriesByFilter(GetAccessLogModel getAccessLogModel,
        CancellationToken cancellationToken);
    
    void Insert(AccessLogEntry accessLogEntry);

}