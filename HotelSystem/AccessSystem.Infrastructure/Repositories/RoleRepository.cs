using AccessSystem.Contracts.Models.Role;
using AccessSystem.Domain.Entities;
using AccessSystem.Domain.Repositories;
using AccessSystem.Infrastructure.Converters;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Application.Core.Abstractions.Data;
using SharedKernel.Contracts.Models.Core;
using SharedKernel.Domain.Core.Primitives.Maybe;
using SharedKernel.Infrastructure.Repositories;

namespace AccessSystem.Infrastructure.Repositories;

public class RoleRepository : GenericRepository<RoleEntity>, IRoleRepository
{
    public RoleRepository(IDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Maybe<PagedList<RoleResponseModel>>> GetRolesByFilter(GetRoleModel getRoleModel, CancellationToken cancellationToken)
    {
        if (getRoleModel is null)
        {
            return Maybe<PagedList<RoleResponseModel>>.None;
        }

        var query = DbContext.Set<RoleEntity>().AsQueryable();
        
        if (getRoleModel.RoleId.HasValue)
        {
            query = query.Where(role => role.Id == getRoleModel.RoleId);
        }

        if (getRoleModel.RoleCodeName is not null)
        {
            query = query.Where(role => role.RoleCodeName == getRoleModel.RoleCodeName);
        }
        
        int totalCount = await query.CountAsync(cancellationToken);
        if (getRoleModel.OrderByDescending)
        {
            query = query.OrderByDescending(EnumerationConverter<RoleEntity>.OrderByConverterToExpression(getRoleModel.OrderBy));
        }
        else
        {
            query = query.OrderBy(EnumerationConverter<RoleEntity>.OrderByConverterToExpression(getRoleModel.OrderBy));
        }
        
        var result = await query.Skip(getRoleModel.Page * getRoleModel.PageSize)
            .Take(getRoleModel.PageSize)
            .Select(role =>
                new RoleResponseModel
                {
                    RoleId = role.Id,
                    RoleCodeName = role.RoleCodeName,
                    RoleName = role.RoleName,
                    RoleDescription = role.RoleDescription,
                    PermissionNames = role.Permissions.Select(permission => permission.PermissionName.Value).ToList()
                }
            )
            .ToArrayAsync(cancellationToken: cancellationToken);
        return new PagedList<RoleResponseModel>(result, getRoleModel.Page, getRoleModel.PageSize, totalCount);
    }
}