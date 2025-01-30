using AccessSystem.Domain.Entities;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace AccessSystem.Domain.Repositories;

public interface IAccessCardRoleRepository
{
    Task<Maybe<AccessCardRole>> GetByIdAsync(Guid id);
    Task ResetRoles(Guid cardId, CancellationToken cancellationToken);

    Task AddRolesToCardById(Guid cardId, IEnumerable<Guid> roleIds, CancellationToken cancellationToken);
    Task AddRolesToCardByName(Guid cardId, IEnumerable<string> roleNames, CancellationToken cancellationToken);
    
    Task RemoveRolesFromCardById(Guid cardId, IEnumerable<string> roleIds,
        CancellationToken cancellationToken);

    Task RemoveRolesFromCardByName(Guid cardId, IEnumerable<string> roleNames,
        CancellationToken cancellationToken);
    
    void Remove(AccessCardRole role);

    void Insert(AccessCardRole role);

}