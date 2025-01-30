using AccessSystem.Domain.Entities;
using AccessSystem.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Application.Core.Abstractions.Data;
using SharedKernel.Domain.Core.Primitives.Maybe;
using SharedKernel.Infrastructure.Repositories;

namespace AccessSystem.Infrastructure.Repositories;

internal class AccessClaimRepository(IDbContext dbContext) : GenericRepository<AccessClaimEntity>(dbContext), IAccessClaimRepository
{
    public new async Task<Maybe<AccessClaimEntity>> GetByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            return Maybe<AccessClaimEntity>.None;
        }

        var accessClaim = DbContext.Set<AccessClaimEntity>().Include(claim => claim.AllowedRoles).AsQueryable();

        var result = await accessClaim.FirstOrDefaultAsync(claim => claim.Id == id);

        if (result is null)
        {
            return Maybe<AccessClaimEntity>.None;
        }

        return Maybe<AccessClaimEntity>.From(result);
    }


    public new async Task Remove(AccessClaimEntity entity)
    {
        var accessClaimRoles = DbContext.Set<AccessClaimRole>().AsQueryable();
        var claimRoles = await accessClaimRoles.Where(accessClaimRole => accessClaimRole.AccessClaimId == entity.Id).ToListAsync();
        DbContext.Set<AccessClaimRole>().RemoveRange(claimRoles);

        DbContext.Set<AccessClaimEntity>().Remove(entity);
    }
}