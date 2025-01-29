using AccessSystem.Domain.Entities;
using AccessSystem.Domain.Repositories;
using SharedKernel.Application.Core.Abstractions.Data;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Application.AccessClaim.Commands.CreateAccessClaim;

public class CreateAccessClaimCommandHandler(IAccessClaimRepository accessClaimRepository, IAccessClaimPermissionRepository accessClaimPermissionRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<CreateAccessClaimCommand, Result>
{
    public async Task<Result> Handle(CreateAccessClaimCommand request, CancellationToken cancellationToken)
    {
        var accessClaim = AccessClaimEntity.Create(request.CreateAccessClaimModel.Name);
        
        accessClaimRepository.Insert(accessClaim);
        await accessClaimPermissionRepository.AddPermissionsToClaimByName(accessClaim.Id,
            request.CreateAccessClaimModel.PermissionCodeNames, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}