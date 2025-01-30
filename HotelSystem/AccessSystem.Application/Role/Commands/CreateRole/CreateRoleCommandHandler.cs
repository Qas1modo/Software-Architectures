using AccessSystem.Domain.Entities;
using AccessSystem.Domain.Repositories;
using SharedKernel.Application.Core.Abstractions.Data;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Application.Role.Commands.CreateRole;

public class CreateRoleCommandHandler(IRoleRepository roleRepository, IUnitOfWork unitOfWork) 
    : ICommandHandler<CreateRoleCommand, Result>
{
    public async Task<Result> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = RoleEntity.Create(request.CreateRoleModel.RoleCodeName, request.CreateRoleModel.RoleName, request.CreateRoleModel.RoleDescription);
        roleRepository.Insert(role);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}