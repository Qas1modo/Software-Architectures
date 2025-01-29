using AccessSystem.Contracts.Models.Permission;
using AccessSystem.Domain.Entities;
using AccessSystem.Domain.Repositories;
using AccessSystem.Infrastructure.Converters;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Application.Core.Abstractions.Data;
using SharedKernel.Contracts.Models.Core;
using SharedKernel.Domain.Core.Primitives.Maybe;
using SharedKernel.Infrastructure.Repositories;

namespace AccessSystem.Infrastructure.Repositories;

internal class PermissionRepository(IDbContext dbContext) : GenericRepository<PermissionEntity>(dbContext), IPermissionRepository
{
    public async Task<Maybe<List<PermissionDetailModel>>> GetPermissionsByFilter(GetPermissionModel getPermissionModel, CancellationToken cancellationToken)
    {
        if (getPermissionModel is null)
        {
            return Maybe<List<PermissionDetailModel>>.None;
        }

        var query = DbContext.Set<PermissionEntity>().AsQueryable();
        
        if (getPermissionModel.PermissionId.HasValue)
        {
            query = query.Where(permission => permission.Id == getPermissionModel.PermissionId);
        }

        if (getPermissionModel.PermissionCodeName is not null)
        {
            query = query.Where(permission => permission.PermissionCodeName == getPermissionModel.PermissionCodeName);
        }
        
        var result = await query.Select(permission =>
                new PermissionDetailModel
                {
                    PermissionId = permission.Id,
                    PermissionCodeName = permission.PermissionCodeName,
                    PermissionName = permission.PermissionName,
                    PermissionDescription = permission.PermissionDescription
                }
            )
            .ToListAsync(cancellationToken: cancellationToken);
        return result;
    }

    public async Task<Maybe<ICollection<PermissionDetailModel>>> GetPermissionsByNames(ICollection<string> names,
        CancellationToken cancellationToken)
    {
        if (names is null || !names.Any())
        {
            return Maybe<ICollection<PermissionDetailModel>>.None;
        }
        
        var query = DbContext.Set<PermissionEntity>().AsQueryable();
        var result = await query.Where(permission => names.Contains(permission.PermissionCodeName))            .Select(permission =>
                new PermissionDetailModel
                {
                    PermissionId = permission.Id,
                    PermissionCodeName = permission.PermissionCodeName,
                    PermissionName = permission.PermissionName,
                    PermissionDescription = permission.PermissionDescription
                }
            )
            .ToListAsync(cancellationToken: cancellationToken);

        return Maybe<ICollection<PermissionDetailModel>>.From(result);
    }
    
    public new async Task Remove(PermissionEntity entity)
    {
        var accessCardPermissions = DbContext.Set<AccessCardPermission>().AsQueryable();
        var cardPermissions = await accessCardPermissions.Where(accessCardPermission => accessCardPermission.PermissionId == entity.Id).ToListAsync();
        DbContext.Set<AccessCardPermission>().RemoveRange(cardPermissions);
        
        var rolePermissions = DbContext.Set<RolePermission>().AsQueryable();
        var rolePermissionsToRemove = await rolePermissions.Where(rolePermission => rolePermission.PermissionId == entity.Id).ToListAsync();
        DbContext.Set<RolePermission>().RemoveRange(rolePermissionsToRemove);
        
        var accessClaimPermissions = DbContext.Set<AccessClaimPermission>().AsQueryable();
        var claimPermissionsToRemove = await accessClaimPermissions.Where(accessClaimPermission => accessClaimPermission.PermissionId == entity.Id).ToListAsync();
        DbContext.Set<AccessClaimPermission>().RemoveRange(claimPermissionsToRemove);
        
        DbContext.Set<PermissionEntity>().Remove(entity);
    }
}