using AccessSystem.Domain.Entities;
using AccessSystem.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Application.Core.Abstractions.Data;
using SharedKernel.Infrastructure.Repositories;

namespace AccessSystem.Infrastructure.Repositories;

internal class AccessClaimPermissionRepository : GenericRepository<AccessClaimPermission>, IAccessClaimPermissionRepository
{
    public AccessClaimPermissionRepository(IDbContext dbContext) : base(dbContext)
    {
    }

    public async Task AddPermissionsToClaimByName(Guid claimId, IEnumerable<string> permissionNames, CancellationToken cancellationToken)
    {
        var accessClaimPermissions = await DbContext.Set<PermissionEntity>().Where(permission => permissionNames.Contains(permission.PermissionCodeName)).Select(permission => new AccessClaimPermission()
        {
            AccessClaimId = claimId,
            PermissionId = permission.Id
        }).ToArrayAsync(cancellationToken);

        await DbContext.Set<AccessClaimPermission>().AddRangeAsync(accessClaimPermissions, cancellationToken);
    }

    public async Task RemovePermissionsFromClaimByName(Guid claimId, IEnumerable<string> permissionNames, CancellationToken cancellationToken)
    {
        var permissions = await DbContext.Set<PermissionEntity>()
            .Where(permission => permissionNames.Contains(permission.PermissionCodeName))
            .Select(permission => permission.Id)
            .ToArrayAsync(cancellationToken);
        
        var permissionsToRemove = await DbContext.Set<AccessClaimPermission>()
            .Where(accessClaimPermission => accessClaimPermission.AccessClaimId == claimId)
            .Where(accessClaimPermission => permissions.Contains(accessClaimPermission.PermissionId))
            .ToArrayAsync(cancellationToken);
        
        DbContext.Set<AccessClaimPermission>().RemoveRange(permissionsToRemove);
    }
}