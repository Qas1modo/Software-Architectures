using AccessSystem.Domain.Entities;
using AccessSystem.Domain.Repositories;
using SharedKernel.Application.Core.Abstractions.Data;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Application.Permissions.Commands.CreatePermission;

public class CreatePermissionCommandHandler(IPermissionRepository permissionRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreatePermissionCommand, Result>
{
    public async Task<Result> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
    {
        var permission = PermissionEntity.Create(request.CreatePermissionModel.PermissionCodeName, request.CreatePermissionModel.PermissionName, request.CreatePermissionModel.PermissionDescription);
        permissionRepository.Insert(permission);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}