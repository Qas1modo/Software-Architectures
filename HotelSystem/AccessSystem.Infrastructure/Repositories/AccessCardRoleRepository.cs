using AccessSystem.Domain.Entities;
using AccessSystem.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Application.Core.Abstractions.Data;
using SharedKernel.Infrastructure.Repositories;

namespace AccessSystem.Infrastructure.Repositories;

internal class AccessCardRoleRepository : GenericRepository<AccessCardRole>, IAccessCardRoleRepository
{
    public AccessCardRoleRepository(IDbContext dbContext) : base(dbContext)
    {
    }

    public async Task ResetRoles(Guid cardId, CancellationToken cancellationToken)
    {
        var roles = await DbContext.Set<AccessCardRole>().Where(accessCardPermission => accessCardPermission.AccessCardId == cardId).ToArrayAsync(cancellationToken);
        DbContext.Set<AccessCardRole>().RemoveRange(roles);
    }
    
    public async Task AddRolesToCardById(Guid cardId, IEnumerable<Guid> roleIds, CancellationToken cancellationToken)
    {
        var roles = roleIds.Select(roleId => new AccessCardRole
        {
            AccessCardId = cardId,
            RoleId = roleId
        });

        await DbContext.Set<AccessCardRole>().AddRangeAsync(roles, cancellationToken);
    }
    
    public async Task AddRolesToCardByName(Guid cardId, IEnumerable<string> roleNames, CancellationToken cancellationToken)
    {
        var roles = await DbContext.Set<RoleEntity>().Where(role => roleNames.Contains(role.RoleCodeName)).Select(role => new AccessCardRole
        {
            AccessCardId = cardId,
            RoleId = role.Id
        }).ToArrayAsync(cancellationToken);

        await DbContext.Set<AccessCardRole>().AddRangeAsync(roles, cancellationToken);
    }

    public async Task RemoveRolesFromCardById(Guid cardId, IEnumerable<string> roleIds, CancellationToken cancellationToken)
    {
        var roles = await DbContext.Set<AccessCardRole>()
            .Where(accessCardRole => accessCardRole.AccessCardId == cardId)
            .Where(accessCardRole => roleIds.Contains(accessCardRole.RoleId.ToString()))
            .ToArrayAsync(cancellationToken);
        
        DbContext.Set<AccessCardRole>().RemoveRange(roles);
    }

    public async Task RemoveRolesFromCardByName(Guid cardId, IEnumerable<string> roleNames, CancellationToken cancellationToken)
    {
        var roles = await DbContext.Set<RoleEntity>()
            .Where(role => roleNames.Contains(role.RoleCodeName))
            .Select(role => role.Id)
            .ToArrayAsync(cancellationToken);

        var rolesToRemove = await DbContext.Set<AccessCardRole>()
            .Where(accessCardRole => accessCardRole.AccessCardId == cardId)
            .Where(accessCardRole => roles.Contains(accessCardRole.RoleId))
            .ToArrayAsync(cancellationToken);
        
        DbContext.Set<AccessCardRole>().RemoveRange(rolesToRemove);
    }
}
