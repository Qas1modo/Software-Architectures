using AccessSystem.Domain.Entities;
using AccessSystem.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Application.Core.Abstractions.Data;
using SharedKernel.Infrastructure.Repositories;

namespace AccessSystem.Infrastructure.Repositories;

public class RolePermissionRepository : GenericRepository<RolePermission>, IRolePermissionRepository
{
    public RolePermissionRepository(IDbContext dbContext) : base(dbContext)
    {
    }
    
    public async Task AddPermissionsToRoleByName(Guid roleId, IEnumerable<string> permissionNames, CancellationToken cancellationToken)
    {
        var permissions = await DbContext.Set<PermissionEntity>().Where(permission => permissionNames.Contains(permission.PermissionCodeName)).Select(permission => new RolePermission()
        {
            RoleId = roleId,
            PermissionId = permission.Id
        }).ToArrayAsync(cancellationToken);

        await DbContext.Set<RolePermission>().AddRangeAsync(permissions, cancellationToken);
    }
    
    public async Task RemovePermissionsFromRoleByName(Guid roleId, IEnumerable<string> permissionNames,
        CancellationToken cancellationToken)
    {
        var permissions = await DbContext.Set<PermissionEntity>()
            .Where(permission => permissionNames.Contains(permission.PermissionCodeName))
            .Select(permission => permission.Id)
            .ToArrayAsync(cancellationToken);

        var permissionsToRemove = await DbContext.Set<RolePermission>()
            .Where(rolePermission => rolePermission.RoleId == roleId)
            .Where(rolePermission => permissions.Contains(rolePermission.PermissionId!.Value))
            .ToArrayAsync(cancellationToken);
        
        DbContext.Set<RolePermission>().RemoveRange(permissionsToRemove);
    }
}