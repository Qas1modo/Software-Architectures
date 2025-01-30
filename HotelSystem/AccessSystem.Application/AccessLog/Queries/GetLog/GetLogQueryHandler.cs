using AccessSystem.Contracts.Models.AccessLogEntry;
using AccessSystem.Domain.Repositories;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Contracts.Models.Core;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace AccessSystem.Application.AccessLog.Queries.GetLog;

public class GetLogQueryHandler(IAccessLogEntryRepository logEntryRepository)
    : IQueryHandler<GetLogQuery, Maybe<PagedList<AccessLogEntryDetailModel>>>
{
    public async Task<Maybe<PagedList<AccessLogEntryDetailModel>>> Handle(GetLogQuery request, CancellationToken cancellationToken)
    {
        return await logEntryRepository.GetLogEntriesByFilter(request.GetAccessLogModel, cancellationToken);
    }
}