using AccessSystem.Domain.Core.Errors;
using AccessSystem.Domain.Repositories;
using SharedKernel.Application.Core.Abstractions.Data;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Application.AccessClaim.Commands.UpdateAccessClaim;

public class UpdateAccessClaimCommandHandler(IAccessClaimRepository accessClaimRepository, IAccessClaimPermissionRepository accessClaimPermissionRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateAccessClaimCommand, Result>
{
    public async Task<Result> Handle(UpdateAccessClaimCommand request, CancellationToken cancellationToken)
    {
        var accessClaim = await accessClaimRepository.GetByIdAsync(request.UpdateAccessClaimModel.Id);
        if (accessClaim.HasNoValue)
        {
            return Result.Failure(DomainErrors.AccessClaimErrors.NotFound);
        }
        
        var permissionsToAdd = request.UpdateAccessClaimModel.PermissionCodeNamesToAdd;
        var permissionsToRemove = request.UpdateAccessClaimModel.PermissionCodeNamesToRemove;
        
        if (permissionsToAdd.Any())
        {
            await accessClaimPermissionRepository.AddPermissionsToClaimByName(accessClaim.Value.Id, permissionsToAdd, cancellationToken);
        }
        
        if (permissionsToRemove.Any())
        {
            await accessClaimPermissionRepository.RemovePermissionsFromClaimByName(accessClaim.Value.Id, permissionsToRemove, cancellationToken);
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