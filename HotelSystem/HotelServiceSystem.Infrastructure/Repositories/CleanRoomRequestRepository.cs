using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Contracts.Models.CleanRoomRequestModels;
using HotelServiceSystem.Contracts.Models.Core;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Domain.Repositories;
using HotelServiceSystem.Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;

namespace HotelServiceSystem.Infrastructure.Repositories;

internal class CleanRoomRequestRepository(IDbContext dbContext)
    : GenericRepository<CleanRoomRequestEntity>(dbContext), ICleanRoomRequestRepository
{

    public async Task<Maybe<PagedList<CleanRoomRequestResponseModel>>> GetNotCompletedRequests(GetAllNotCompletedCleanRequestsPagedModel pagination,
        CancellationToken cancellationToken)
    {
        var query = DbContext.Set<CleanRoomRequestEntity>().AsQueryable()
            .AsNoTracking()
            .Where(new NotCompletedCleanRequestsSpecification());
        var totalCount = await query.CountAsync(cancellationToken);
        var result = await query
        .Skip((pagination.Page - 1) * pagination.PageSize)
        .Take(pagination.PageSize)
        .Select(crr => new CleanRoomRequestResponseModel
        {
            CleanRoomRequestGuid = crr.Id,
            Deadline = crr.Deadline,
            RoomNumber = crr.RoomNumber.Value,
        })
        .ToListAsync(cancellationToken);
        return new PagedList<CleanRoomRequestResponseModel>(result, pagination.Page, pagination.PageSize, totalCount);
    }

    public async Task<Result> MarkAsCompleted(Guid cleanRoomRequestId)
    {
        var request = await GetByIdAsync(cleanRoomRequestId);
        if (request.HasNoValue)
        {
            return Result.Failure(DomainErrors.CleanRoomRequestErrors.NotFound);
        }
        request.Value.MarkAsCompleted();
        return Result.Success();
    }
}
