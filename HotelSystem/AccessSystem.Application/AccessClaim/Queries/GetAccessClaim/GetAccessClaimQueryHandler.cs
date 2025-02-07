using AccessSystem.Contracts.Models.AccessClaim;
using AccessSystem.Domain.Repositories;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace AccessSystem.Application.AccessClaim.Queries.GetAccessClaim;

public class GetAccessClaimQueryHandler(IAccessClaimRepository accessClaimRepository)
    : IQueryHandler<GetAccessClaimQuery, Maybe<List<AccessClaimResponseModel>>>
{
    public async Task<Maybe<List<AccessClaimResponseModel>>> Handle(GetAccessClaimQuery request, CancellationToken cancellationToken)
    {
        if (request.GetAccessClaimModel.Id == null)
        {
            var accessClaims = await accessClaimRepository.GetAllAsync();
            if (accessClaims.HasNoValue)
            {
                return Maybe<List<AccessClaimResponseModel>>.None;
            }

            return accessClaims.Value.Select(accessClaim => new AccessClaimResponseModel
            {
                Id = accessClaim.Id,
                AllowedRoles = accessClaim.AllowedRoles.Select(p => p.RoleCodeName).ToList()
            }).ToList();
        }
        var accessClaim = await accessClaimRepository.GetByIdAsync(request.GetAccessClaimModel.Id.Value);
        
        if (accessClaim.HasNoValue)
        {
            return Maybe<List<AccessClaimResponseModel>>.None;
        }


        return new List<AccessClaimResponseModel>()
        {
            new AccessClaimResponseModel
            {
                Id = accessClaim.Value.Id,
                AllowedRoles = accessClaim.Value.AllowedRoles.Select(p => p.RoleCodeName).ToList()
            }
        };
    }
}