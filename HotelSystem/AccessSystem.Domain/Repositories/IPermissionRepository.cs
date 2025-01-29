using AccessSystem.Contracts.Models.Permission;
using AccessSystem.Domain.Entities;
using SharedKernel.Contracts.Models.Core;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace AccessSystem.Domain.Repositories;

public interface IPermissionRepository
{
    Task<Maybe<List<PermissionDetailModel>>> GetPermissionsByFilter(GetPermissionModel getPermissionModel,
        CancellationToken cancellationToken);

    Task<Maybe<ICollection<PermissionDetailModel>>> GetPermissionsByNames(ICollection<string> names,
        CancellationToken cancellationToken);
    
    Task<Maybe<PermissionEntity>> GetByIdAsync(Guid id);
    
    Task Remove(PermissionEntity permission);

    void Insert(PermissionEntity permission);

    void Update(PermissionEntity permission);
}