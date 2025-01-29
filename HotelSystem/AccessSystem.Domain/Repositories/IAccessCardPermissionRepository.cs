using AccessSystem.Domain.Entities;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace AccessSystem.Domain.Repositories;

public interface IAccessCardPermissionRepository
{
    Task<Maybe<AccessCardPermission>> GetByIdAsync(Guid id);
    Task ResetPermissions(Guid cardId, CancellationToken cancellationToken);
    
    Task AddPermissionsToCardById(Guid cardId, IEnumerable<Guid> permissionIds, CancellationToken cancellationToken);
    Task AddPermissionsToCardByName(Guid cardId, IEnumerable<string> permissionNames, CancellationToken cancellationToken);

    Task RemovePermissionsFromCardById(Guid cardId, IEnumerable<string> permissionIds,
        CancellationToken cancellationToken);

    Task RemovePermissionsFromCardByName(Guid cardId, IEnumerable<string> permissionNames,
        CancellationToken cancellationToken);
    
    void Remove(AccessCardPermission permission);

    void Insert(AccessCardPermission permission);
}