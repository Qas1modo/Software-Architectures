using AccessSystem.Contracts.Models.Role;
using AccessSystem.Domain.Entities;
using SharedKernel.Contracts.Models.Core;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace AccessSystem.Domain.Repositories;

public interface IRoleRepository
{
    Task<Maybe<PagedList<RoleResponseModel>>> GetRolesByFilter(GetRoleModel getRoleModel, CancellationToken cancellationToken);
    void Remove(RoleEntity role);

    void Insert(RoleEntity role);

    void Update(RoleEntity role);
}