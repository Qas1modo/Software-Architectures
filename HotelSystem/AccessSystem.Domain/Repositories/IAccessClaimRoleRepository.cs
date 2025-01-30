using AccessSystem.Domain.Entities;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace AccessSystem.Domain.Repositories;

public interface IAccessClaimRoleRepository
{
    Task<Maybe<AccessClaimRole>> GetByIdAsync(Guid id);

    Task AddRolesToClaimByName(Guid claimId, IEnumerable<string> roleNames, CancellationToken cancellationToken);
    Task RemoveRolesFromClaimByName(Guid claimId, IEnumerable<string> roleNames, CancellationToken cancellationToken);


    void Remove(AccessClaimRole role);

    void Insert(AccessClaimRole role);
}