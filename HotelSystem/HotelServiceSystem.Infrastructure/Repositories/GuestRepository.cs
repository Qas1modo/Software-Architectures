using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HotelServiceSystem.Infrastructure.Repositories;

internal class GuestRepository(IDbContext dbContext) : GenericRepository<GuestEntity>(dbContext), IGuestRepository
{
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