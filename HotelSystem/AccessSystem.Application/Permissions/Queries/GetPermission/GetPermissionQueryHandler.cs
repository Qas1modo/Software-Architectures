using AccessSystem.Contracts.Models.Permission;
using AccessSystem.Domain.Repositories;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Contracts.Models.Core;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace AccessSystem.Application.Permissions.Queries.GetPermission;

public class GetPermissionQueryHandler(IPermissionRepository permissionRepository) : IQueryHandler<GetPermissionQuery, Maybe<List<PermissionDetailModel>>>
{
    public async Task<Maybe<List<PermissionDetailModel>>> Handle(GetPermissionQuery request, CancellationToken cancellationToken)
    {
        return await permissionRepository.GetPermissionsByFilter(request.GetPermissionModel, cancellationToken);
    }
}