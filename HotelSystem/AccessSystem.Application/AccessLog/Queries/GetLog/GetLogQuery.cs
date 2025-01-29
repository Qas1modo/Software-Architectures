using AccessSystem.Contracts.Models.AccessLogEntry;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Contracts.Models.Core;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace AccessSystem.Application.AccessLog.Queries.GetLog;

public record GetLogQuery(GetAccessLogModel GetAccessLogModel) : IQuery<Maybe<PagedList<AccessLogEntryDetailModel>>>;