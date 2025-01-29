using AccessSystem.Contracts.Models.AccessCard;
using AccessSystem.Domain.Repositories;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace AccessSystem.Application.AccessCard.Queries.GetCard;

public class GetCardQueryHandler(IAccessCardRepository accessCardRepository)
    : IQueryHandler<GetCardQuery, Maybe<AccessCardResponseModel>>
{
    public async Task<Maybe<AccessCardResponseModel>> Handle(GetCardQuery request, CancellationToken cancellationToken)
    {
        var accessCard = await accessCardRepository.GetByIdAsync(request.GetAccessCardModel.Id);
        if (accessCard.HasNoValue)
        {
            return Maybe<AccessCardResponseModel>.None;
        }
        
        return new AccessCardResponseModel()
        {
            Id = accessCard.Value.Id,
            RoleNames = accessCard.Value.Roles.Select(r => r.RoleCodeName).ToList(),
            PermissionNames = accessCard.Value.Permissions.Select(r => r.PermissionCodeName).ToList()
        };
    }
}