using AccessSystem.Domain.Entities;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace AccessSystem.Domain.Repositories;

public interface IRolePermissionRepository
{
    Task<Maybe<RolePermission>> GetByIdAsync(Guid id);

    Task AddPermissionsToRoleByName(Guid roleId, IEnumerable<string> permissionNames,
        CancellationToken cancellationToken);

    Task RemovePermissionsFromRoleByName(Guid roleId, IEnumerable<string> permissionNames,
        CancellationToken cancellationToken);
}