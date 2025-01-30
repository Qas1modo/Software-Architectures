using AccessSystem.Contracts.Models.Role;
using AccessSystem.Domain.Repositories;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Contracts.Models.Core;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace AccessSystem.Application.Role.Queries.GetRole;

public class GetRoleQueryHandler(IRoleRepository roleRepository)
    : IQueryHandler<GetRoleQuery, Maybe<PagedList<RoleResponseModel>>>
{
    public async Task<Maybe<PagedList<RoleResponseModel>>> Handle(GetRoleQuery request, CancellationToken cancellationToken)
    {
        return await roleRepository.GetRolesByFilter(request.GetRoleModel, cancellationToken);
    }
}