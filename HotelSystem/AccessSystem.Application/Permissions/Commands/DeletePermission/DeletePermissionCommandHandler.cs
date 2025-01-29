using AccessSystem.Domain.Core.Errors;
using AccessSystem.Domain.Repositories;
using SharedKernel.Application.Core.Abstractions.Data;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Application.Permissions.Commands.DeletePermission;

public class DeletePermissionCommandHandler(IPermissionRepository permissionRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<DeletePermissionCommand, Result>
{
    public async Task<Result> Handle(DeletePermissionCommand request, CancellationToken cancellationToken)
    {
        var permission = await permissionRepository.GetByIdAsync(request.DeletePermissionModel.PermissionId);
        if (permission.HasNoValue)
        {
            return Result.Failure(DomainErrors.PermissionErrors.NotFound);
        }
        
        await permissionRepository.Remove(permission.Value);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}