using AccessSystem.Domain.Core.Errors;
using AccessSystem.Domain.Repositories;
using SharedKernel.Application.Core.Abstractions.Data;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Application.Permissions.Commands.UpdatePermission;

public class UpdatePermissionCommandHandler(IPermissionRepository permissionRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<UpdatePermissionCommand, Result>
{
    public async Task<Result> Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
    {
        var permission = await permissionRepository.GetByIdAsync(request.UpdatePermissionModel.PermissionId);
        if (permission.HasNoValue)
        {
            return Result.Failure(DomainErrors.PermissionErrors.NotFound);
        }
        
        var updatedEntity = permission.Value.Update(request.UpdatePermissionModel.PermissionCodeName, request.UpdatePermissionModel.PermissionName, request.UpdatePermissionModel.PermissionDescription);
        permissionRepository.Update(updatedEntity);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}