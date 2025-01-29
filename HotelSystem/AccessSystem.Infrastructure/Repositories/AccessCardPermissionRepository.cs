using AccessSystem.Domain.Entities;
using AccessSystem.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Application.Core.Abstractions.Data;
using SharedKernel.Infrastructure.Repositories;

namespace AccessSystem.Infrastructure.Repositories;

internal class AccessCardPermissionRepository : GenericRepository<AccessCardPermission>, IAccessCardPermissionRepository
{
    public AccessCardPermissionRepository(IDbContext dbContext) : base(dbContext)
    {
    }
    
    public async Task ResetPermissions(Guid cardId, CancellationToken cancellationToken)
    {
        var permissions = await DbContext.Set<AccessCardPermission>().Where(accessCardPermission => accessCardPermission.AccessCardId == cardId).ToArrayAsync(cancellationToken);
        DbContext.Set<AccessCardPermission>().RemoveRange(permissions);
    }

    public async Task AddPermissionsToCardById(Guid cardId, IEnumerable<Guid> permissionIds, CancellationToken cancellationToken)
    {
        var permissions = permissionIds.Select(permissionId => new AccessCardPermission()
        {
            AccessCardId = cardId,
            PermissionId = permissionId
        });

        await DbContext.Set<AccessCardPermission>().AddRangeAsync(permissions, cancellationToken);
    }

    public async Task AddPermissionsToCardByName(Guid cardId, IEnumerable<string> permissionNames, CancellationToken cancellationToken)
    {
        var permissions = await DbContext.Set<PermissionEntity>().Where(permission => permissionNames.Contains(permission.PermissionCodeName)).Select(permission => new AccessCardPermission
        {
            AccessCardId = cardId,
            PermissionId = permission.Id
        }).ToArrayAsync(cancellationToken);

        await DbContext.Set<AccessCardPermission>().AddRangeAsync(permissions, cancellationToken);
    }

    public async Task RemovePermissionsFromCardById(Guid cardId, IEnumerable<string> permissionIds,
        CancellationToken cancellationToken)
    {
        var permissions = await DbContext.Set<AccessCardPermission>()
            .Where(accessCardPermission => accessCardPermission.AccessCardId == cardId)
            .Where(accessCardPermission => permissionIds.Contains(accessCardPermission.PermissionId.ToString()))
            .ToArrayAsync(cancellationToken);
        
        DbContext.Set<AccessCardPermission>().RemoveRange(permissions);
    }
    
    public async Task RemovePermissionsFromCardByName(Guid cardId, IEnumerable<string> permissionNames,
        CancellationToken cancellationToken)
    {
        var permissions = await DbContext.Set<PermissionEntity>()
            .Where(permission => permissionNames.Contains(permission.PermissionCodeName))
            .Select(permission => permission.Id)
            .ToArrayAsync(cancellationToken);

        var permissionsToRemove = await DbContext.Set<AccessCardPermission>()
            .Where(accessCardPermission => accessCardPermission.AccessCardId == cardId)
            .Where(accessCardPermission => permissions.Contains(accessCardPermission.PermissionId))
            .ToArrayAsync(cancellationToken);
        
        DbContext.Set<AccessCardPermission>().RemoveRange(permissionsToRemove);
    }
}