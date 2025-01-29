using AccessSystem.Domain.Core.Errors;
using AccessSystem.Domain.Repositories;
using SharedKernel.Application.Core.Abstractions.Data;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Application.Role.Commands.UpdateRole;

public class UpdateRoleCommandHandler(IRoleRepository roleRepository, IRolePermissionRepository rolePermissionRepository, IUnitOfWork unitOfWork) 
    : ICommandHandler<UpdateRoleCommand, Result>
{
    public async Task<Result> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await roleRepository.GetByIdAsync(request.UpdateRoleModel.RoleId);

        if (role.HasNoValue)
        {
            return Result.Failure(DomainErrors.RoleErrors.NotFound);
        }

        role.Value.RoleCodeName = request.UpdateRoleModel.RoleCodeName ?? role.Value.RoleCodeName;
        role.Value.RoleName = request.UpdateRoleModel.RoleName ?? role.Value.RoleName;
        role.Value.RoleDescription = request.UpdateRoleModel.RoleDescription ?? role.Value.RoleDescription;
        
        roleRepository.Update(role);
        
        if (request.UpdateRoleModel.PermissionCodeNamesToAdd.Any())
        {
            await rolePermissionRepository.AddPermissionsToRoleByName(role.Value.Id, request.UpdateRoleModel.PermissionCodeNamesToAdd, cancellationToken);
        }
        
        if (request.UpdateRoleModel.PermissionCodeNamesToRemove.Any())
        {
            await rolePermissionRepository.RemovePermissionsFromRoleByName(role.Value.Id, request.UpdateRoleModel.PermissionCodeNamesToRemove, cancellationToken);
        }
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}