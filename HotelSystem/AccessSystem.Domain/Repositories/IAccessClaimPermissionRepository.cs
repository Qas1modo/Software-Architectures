using AccessSystem.Domain.Entities;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace AccessSystem.Domain.Repositories;

public interface IAccessClaimPermissionRepository
{
    Task<Maybe<AccessClaimPermission>> GetByIdAsync(Guid id);
    
    Task AddPermissionsToClaimByName(Guid claimId, IEnumerable<string> permissionNames, CancellationToken cancellationToken);
    Task RemovePermissionsFromClaimByName(Guid claimId, IEnumerable<string> permissionNames, CancellationToken cancellationToken);

    
    void Remove(AccessClaimPermission role);

    void Insert(AccessClaimPermission role);
}