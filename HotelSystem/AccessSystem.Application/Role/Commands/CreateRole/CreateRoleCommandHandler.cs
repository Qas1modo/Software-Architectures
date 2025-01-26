using AccessSystem.Domain.Entities;
using AccessSystem.Domain.Repositories;
using AccessSystem.Domain.ValueObjects;
using SharedKernel.Application.Core.Abstractions.Data;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Application.Role.Commands.CreateRole;

public class CreateRoleCommandHandler(IRoleRepository roleRepository, IUnitOfWork unitOfWork) 
    : ICommandHandler<CreateRoleCommand, Result>
{
    public async Task<Result> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        Result<RoleName> roleName = RoleName.Create(request.CreateRoleModel.RoleName);
        Result<RoleDescription> roleDescription = RoleDescription.Create(request.CreateRoleModel.RoleDescription);
        
        Result firstFailureOrSuccess = Result.FirstFailureOrSuccess(roleName, roleDescription);
        if (firstFailureOrSuccess.IsFailure)
        {
            return Result.Failure(firstFailureOrSuccess.Error);
        }
        
        var role = RoleEntity.Create(request.CreateRoleModel.RoleCodeName, roleName.Value, roleDescription.Value);
        roleRepository.Insert(role);
        await unitOfWork.SaveChangesAsync(cancellationToken);
            
        return Result.Success();
    }
}