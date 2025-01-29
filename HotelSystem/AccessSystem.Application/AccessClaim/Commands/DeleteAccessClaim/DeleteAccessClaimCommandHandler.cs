using AccessSystem.Domain.Core.Errors;
using AccessSystem.Domain.Repositories;
using SharedKernel.Application.Core.Abstractions.Data;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Application.AccessClaim.Commands.DeleteAccessClaim;

public class DeleteAccessClaimCommandHandler(IAccessClaimRepository accessClaimRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteAccessClaimCommand, Result>
{
    public async Task<Result> Handle(DeleteAccessClaimCommand request, CancellationToken cancellationToken)
    {
        var accessClaim = await accessClaimRepository.GetByIdAsync(request.DeleteAccessClaimModel.Id);

        if (accessClaim.HasValue)
        {
            return Result.Failure(DomainErrors.AccessClaimErrors.NotFound);
        }

        await accessClaimRepository.Remove(accessClaim);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}