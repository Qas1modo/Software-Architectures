using AccessSystem.Contracts.Models.AccessLogEntry;
using AccessSystem.Domain.Entities;
using AccessSystem.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Application.Core.Abstractions.Data;
using SharedKernel.Contracts.Models.Core;
using SharedKernel.Domain.Core.Primitives.Maybe;
using SharedKernel.Infrastructure.Repositories;

namespace AccessSystem.Infrastructure.Repositories;

internal class AccessLogEntryRepository : GenericRepository<AccessLogEntry>, IAccessLogEntryRepository
{
    public AccessLogEntryRepository(IDbContext dbContext) : base(dbContext)
    {
    }
    
    public async Task<Maybe<PagedList<AccessLogEntryDetailModel>>> GetLogEntriesByFilter(GetAccessLogModel getAccessLogModel,
        CancellationToken cancellationToken)
    {
        if (getAccessLogModel is null)
        {
            return Maybe<PagedList<AccessLogEntryDetailModel>>.None;
        }
        
        var query = DbContext.Set<AccessLogEntry>().AsQueryable();
        
        if (getAccessLogModel.AccessLogId.HasValue)
        {
            query = query.Where(x => x.Id == getAccessLogModel.AccessLogId);
        }
        
        if (getAccessLogModel.TimeFrom.HasValue)
        {
            query = query.Where(x => x.CreatedOnUtc >= getAccessLogModel.TimeFrom);
        }

        if (getAccessLogModel.TimeTo.HasValue)
        {
            query = query.Where(x => x.CreatedOnUtc <= getAccessLogModel.TimeTo);
        }
        
        if (getAccessLogModel.AccessCardId.HasValue)
        {
            query = query.Where(x => x.AccessCardId == getAccessLogModel.AccessCardId);
        }
        
        if (getAccessLogModel.RoomId.HasValue)
        {
            query = query.Where(x => x.AccessClaimId == getAccessLogModel.RoomId);
        }
        
        int totalCount = await query.CountAsync(cancellationToken);
        
        var result = await query.Skip(getAccessLogModel.Page * getAccessLogModel.PageSize)
            .Take(getAccessLogModel.PageSize)
            .Select(entry =>
                new AccessLogEntryDetailModel
                {
                    AccessLogEntryId = entry.Id,
                    AccessCardId = entry.AccessCardId,
                    RoomId = entry.AccessClaimId,
                    AccessDateTime = entry.CreatedOnUtc,
                    IsEntryAllowed = entry.IsEntryAllowed
                }
            )
            .ToArrayAsync(cancellationToken: cancellationToken);

        return new PagedList<AccessLogEntryDetailModel>(result, getAccessLogModel.Page, getAccessLogModel.PageSize, totalCount);
    }
}