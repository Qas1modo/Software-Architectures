using AccessSystem.Domain.Core.Errors;
using AccessSystem.Domain.Repositories;
using SharedKernel.Application.Core.Abstractions.Data;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Application.Role.Commands.DeleteRole;

public class DeleteRoleCommandHandler(IRoleRepository roleRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteRoleCommand, Result>
{
    public async Task<Result> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await roleRepository.GetByIdAsync(request.DeleteRoleModel.RoleId);

        if (role.HasNoValue)
        {
            return Result.Failure(DomainErrors.RoleErrors.NotFound);
        }

        await roleRepository.Remove(role);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}