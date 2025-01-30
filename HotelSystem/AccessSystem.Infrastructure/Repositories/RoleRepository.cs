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

        var result = await query.Skip(getRoleModel.Page * getRoleModel.PageSize)
            .Take(getRoleModel.PageSize)
            .Select(role =>
                new RoleResponseModel
                {
                    RoleId = role.Id,
                    RoleCodeName = role.RoleCodeName,
                    RoleName = role.RoleName,
                    RoleDescription = role.RoleDescription,
                }
            )
            .ToArrayAsync(cancellationToken: cancellationToken);
        return new PagedList<RoleResponseModel>(result, getRoleModel.Page, getRoleModel.PageSize, totalCount);
    }

    public async Task<Maybe<ICollection<RoleResponseModel>>> GetRolesByNames(ICollection<string> names, CancellationToken cancellationToken)
    {
        if (names is null || !names.Any())
        {
            return Maybe<ICollection<RoleResponseModel>>.None;
        }

        var query = DbContext.Set<RoleEntity>().AsQueryable();
        var result = await query.Where(role => names.Contains(role.RoleCodeName)).Select(role =>
                new RoleResponseModel
                {
                    RoleId = role.Id,
                    RoleCodeName = role.RoleCodeName,
                    RoleName = role.RoleName,
                    RoleDescription = role.RoleDescription
                }
            )
            .ToListAsync(cancellationToken: cancellationToken);

        return Maybe<ICollection<RoleResponseModel>>.From(result);
    }

    public new async Task Remove(RoleEntity entity)
    {
        var accessCardRoles = DbContext.Set<AccessCardRole>().AsQueryable();
        var cardRoles = await accessCardRoles.Where(accessCardRole => accessCardRole.RoleId == entity.Id).ToListAsync();
        DbContext.Set<AccessCardRole>().RemoveRange(cardRoles);
        
        var accessClaimsRoles = DbContext.Set<AccessClaimRole>().AsQueryable();
        var claims = await accessClaimsRoles.Where(accessClaim => accessClaim.RoleId == entity.Id).ToListAsync();
        DbContext.Set<AccessClaimRole>().RemoveRange(claims);

        DbContext.Set<RoleEntity>().Remove(entity);
    }
}