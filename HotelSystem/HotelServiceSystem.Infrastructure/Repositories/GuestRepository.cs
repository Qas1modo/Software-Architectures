using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Contracts.Models.Core;
using HotelServiceSystem.Contracts.Models.Guest;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HotelServiceSystem.Infrastructure.Repositories;

internal class GuestRepository(IDbContext dbContext) : GenericRepository<GuestEntity>(dbContext), IGuestRepository
{
    public async Task<Maybe<PagedList<GuestResponseModel>>> GetGuestsAsync(GetAllGuestsPaged request, CancellationToken cancellationToken)
    {
        var query = DbContext.Set<GuestEntity>().AsQueryable()
            .AsNoTracking()
            .Where(g => g.Active == !request.IsDisabled);
        var totalCount = await query.CountAsync(cancellationToken);
        var result = await query
        .Skip((request.Page - 1) * request.PageSize)
        .Take(request.PageSize)
        .Select(g => new GuestResponseModel
        {
            GuestEmail = g.Email,
            Active = g.Active,
            GuestFirstName = g.GuestFirstName,
            GuestLastName = g.GuestLastName,
            GuestId = g.Id,
            GuestRoomNumber = g.GuestRoomNumber,
            GlobalGuestId = g.GlobalGuestId,
            CreatedOnUtc = g.CreatedOnUtc,
            ModifiedOnUtc = g.ModifiedOnUtc
        })
        .ToListAsync(cancellationToken);
        return new PagedList<GuestResponseModel>(result, request.Page, request.PageSize, totalCount);
    }

    public async Task<Result> DeactivateGuest(Guid externalGuestId)
    {
        var guest = await DbContext.Set<GuestEntity>().AsQueryable().Where(g => g.GlobalGuestId == externalGuestId)
            .FirstOrDefaultAsync();
        if (guest is null)
        {
            return Result.Failure(DomainErrors.GuestErrors.InvalidGlobalGuestId);
        }
        guest.DeactivateGuest();
        if (guest is null)
        {
            return Result.Failure(DomainErrors.GuestErrors.AlreadyInactive);
        }
        return Result.Success();
    }
}