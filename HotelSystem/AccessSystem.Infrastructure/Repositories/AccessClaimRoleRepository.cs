using AccessSystem.Domain.Entities;
using AccessSystem.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Application.Core.Abstractions.Data;
using SharedKernel.Infrastructure.Repositories;

namespace AccessSystem.Infrastructure.Repositories;

internal class AccessClaimRoleRepository : GenericRepository<AccessClaimRole>, IAccessClaimRoleRepository
{
    public AccessClaimRoleRepository(IDbContext dbContext) : base(dbContext)
    {
    }

    public async Task AddRolesToClaimByName(Guid claimId, IEnumerable<string> roleNames, CancellationToken cancellationToken)
    {
        var accessClaimRoles = await DbContext.Set<RoleEntity>().Where(role => roleNames.Contains(role.RoleCodeName)).Select(role => new AccessClaimRole()
        {
            AccessClaimId = claimId,
            RoleId = role.Id
        }).ToArrayAsync(cancellationToken);

        await DbContext.Set<AccessClaimRole>().AddRangeAsync(accessClaimRoles, cancellationToken);
    }

    public async Task RemoveRolesFromClaimByName(Guid claimId, IEnumerable<string> roleNames, CancellationToken cancellationToken)
    {
        var roles = await DbContext.Set<RoleEntity>()
            .Where(role => roleNames.Contains(role.RoleCodeName))
            .Select(role => role.Id)
            .ToArrayAsync(cancellationToken);

        var rolesToRemove = await DbContext.Set<AccessClaimRole>()
            .Where(accessClaimRole => accessClaimRole.AccessClaimId == claimId)
            .Where(accessClaimRole => roles.Contains(accessClaimRole.RoleId))
            .ToArrayAsync(cancellationToken);

        DbContext.Set<AccessClaimRole>().RemoveRange(rolesToRemove);
    }
}