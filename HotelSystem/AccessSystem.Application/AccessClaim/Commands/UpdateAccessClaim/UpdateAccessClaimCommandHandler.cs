using AccessSystem.Domain.Core.Errors;
using AccessSystem.Domain.Repositories;
using SharedKernel.Application.Core.Abstractions.Data;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Application.AccessClaim.Commands.UpdateAccessClaim;

public class UpdateAccessClaimCommandHandler(IAccessClaimRepository accessClaimRepository, IAccessClaimRoleRepository accessClaimRoleRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateAccessClaimCommand, Result>
{
    public async Task<Result> Handle(UpdateAccessClaimCommand request, CancellationToken cancellationToken)
    {
        var accessClaim = await accessClaimRepository.GetByIdAsync(request.UpdateAccessClaimModel.Id);
        if (accessClaim.HasNoValue)
        {
            return Result.Failure(DomainErrors.AccessClaimErrors.NotFound);
        }

        var rolesToAdd = request.UpdateAccessClaimModel.RoleCodeNamesToAdd;
        var RolesToRemove = request.UpdateAccessClaimModel.RoleCodeNamesToRemove;

        if (rolesToAdd.Any())
        {
            await accessClaimRoleRepository.AddRolesToClaimByName(accessClaim.Value.Id, rolesToAdd, cancellationToken);
        }

        if (RolesToRemove.Any())
        {
            await accessClaimRoleRepository.RemoveRolesFromClaimByName(accessClaim.Value.Id, RolesToRemove, cancellationToken);
        }

        if (request.UpdateAccessClaimModel.Name is not null && request.UpdateAccessClaimModel.Name != String.Empty)
        {
            accessClaim.Value.CodeName = request.UpdateAccessClaimModel.Name;
            accessClaimRepository.Update(accessClaim.Value);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}