using AccessSystem.Contracts.Models.AccessClaim;
using AccessSystem.Domain.Repositories;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace AccessSystem.Application.AccessClaim.Queries.GetAccessClaim;

public class GetAccessClaimQueryHandler(IAccessClaimRepository accessClaimRepository)
    : IQueryHandler<GetAccessClaimQuery, Maybe<AccessClaimResponseModel>>
{
    public async Task<Maybe<AccessClaimResponseModel>> Handle(GetAccessClaimQuery request, CancellationToken cancellationToken)
    {
        var accessClaim = await accessClaimRepository.GetByIdAsync(request.GetAccessClaimModel.Id);
        
        if (accessClaim.HasNoValue)
        {
            return Maybe<AccessClaimResponseModel>.None;
        }
        
        return new AccessClaimResponseModel
        {
            Id = accessClaim.Value.Id,
            AllowedRoles = accessClaim.Value.AllowedRoles.Select(p => p.RoleCodeName).ToList(),
        };
    }
}