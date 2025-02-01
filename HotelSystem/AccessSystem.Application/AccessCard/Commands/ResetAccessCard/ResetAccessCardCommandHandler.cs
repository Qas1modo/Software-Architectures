using AccessSystem.Domain.Core.Errors;
using AccessSystem.Domain.Repositories;
using SharedKernel.Application.Core.Abstractions.Data;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Application.AccessCard.Commands.ResetAccessCard;

public class ResetAccessCardCommandHandler(IAccessCardRepository accessCardRepository, IAccessCardRoleRepository accessCardRoleRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<ResetAccessCardCommand, Result>
{
    public async Task<Result> Handle(ResetAccessCardCommand request, CancellationToken cancellationToken)
    {
        var cardId = request.ResetAccessCardModel.Id ?? Guid.Empty;
        if (request.ResetAccessCardModel.HolderId is not null)
        {
            var result = await accessCardRepository.GetByHolderId(request.ResetAccessCardModel.HolderId.Value);
            
            if (result.HasNoValue && cardId == Guid.Empty)
            {
                return Result.Failure(DomainErrors.AccessCardErrors.NotFound);
            }
            
            if (result.HasValue && cardId == Guid.Empty)
            {
                cardId = result.Value.Id;
            }
            
            if (cardId != Guid.Empty && result.HasValue && result.Value.Id != cardId)
            {
                return Result.Failure(DomainErrors.AccessCardErrors.NotFound);
            }
        }
        
        var accessCard = await accessCardRepository.GetByIdAsync(cardId);
        
        if (accessCard.HasNoValue)
        {
            return Result.Failure(DomainErrors.AccessCardErrors.NotFound);
        }
        
        
        await accessCardRoleRepository.ResetRoles(cardId, cancellationToken);

        accessCard.Value.HolderId = null;
        accessCardRepository.Update(accessCard.Value);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}