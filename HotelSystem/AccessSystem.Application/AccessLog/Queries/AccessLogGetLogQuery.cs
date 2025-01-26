using AccessSystem.Contracts.Models.AccessLogEntry;
using MediatR;
using SharedKernel.Contracts.Models.Core;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace AccessSystem.Application.AccessLog.Queries;

public record AccessLogGetLogQuery(GetAccessLogModel GetAccessLogModel) : IRequest<Maybe<PagedList<AccessLogEntryDetailModel>>>;