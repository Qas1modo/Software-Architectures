using AccessSystem.Contracts.Models.AccessCard;
using AccessSystem.Domain.Repositories;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace AccessSystem.Application.AccessCard.Queries.GetCard;

public class GetCardQueryHandler(IAccessCardRepository accessCardRepository)
    : IQueryHandler<GetCardQuery, Maybe<List<AccessCardResponseModel>>>
{
    public async Task<Maybe<List<AccessCardResponseModel>>> Handle(GetCardQuery request, CancellationToken cancellationToken)
    {
        if (request.GetAccessCardModel.Id == null)
        {
            var allCards = await accessCardRepository.GetAllAsync();

            if (allCards.HasNoValue)
            {
                return Maybe<List<AccessCardResponseModel>>.None;
            }
            
            var result = new List<AccessCardResponseModel>();
            foreach (var card in allCards.Value)
            {
                var singleCard = new AccessCardResponseModel()
                {
                    Id = card.Id,
                    RoleNames = card.Roles.Select(r => r.RoleCodeName).ToList(),
                    HolderId = card.HolderId
                };
                result.Add(singleCard);
            }
            return result;
        }
        
        var accessCard = await accessCardRepository.GetByIdAsync(request.GetAccessCardModel.Id.Value);
        if (accessCard.HasNoValue)
        {
            return Maybe<List<AccessCardResponseModel>>.None;
        }

        var single = new AccessCardResponseModel()
        {
            Id = accessCard.Value.Id,
            RoleNames = accessCard.Value.Roles.Select(r => r.RoleCodeName).ToList(),
            HolderId = accessCard.Value.HolderId
        };
        
        return new List<AccessCardResponseModel> { single };

    }
}