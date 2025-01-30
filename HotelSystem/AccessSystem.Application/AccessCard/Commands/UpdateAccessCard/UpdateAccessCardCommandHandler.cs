using AccessSystem.Domain.Core.Errors;
using AccessSystem.Domain.Repositories;
using SharedKernel.Application.Core.Abstractions.Data;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Application.AccessCard.Commands.UpdateAccessCard;

public class UpdateAccessCardCommandHandler(IAccessCardRepository accessCardRepository, IAccessCardRoleRepository accessCardRoleRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateAccessCardCommand, Result>
{
    public async Task<Result> Handle(UpdateAccessCardCommand request, CancellationToken cancellationToken)
    {
        Guid cardId = request.UpdateAccessCardModel.CardId ?? Guid.Empty;
        if (request.UpdateAccessCardModel.HolderId is not null)
        {
            var result = await accessCardRepository.GetByHolderId(request.UpdateAccessCardModel.HolderId.Value);

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

        var rolesToAdd = request.UpdateAccessCardModel.RoleNamesToAdd;
        var rolesToRemove = request.UpdateAccessCardModel.RoleNamesToRemove;


        if (rolesToAdd.Any())
        {
            await accessCardRoleRepository.AddRolesToCardByName(accessCard.Value.Id, rolesToAdd,
                cancellationToken);
        }

        if (rolesToRemove.Any())
        {
            await accessCardRoleRepository.RemoveRolesFromCardByName(accessCard.Value.Id, rolesToRemove,
                cancellationToken);

        }

        if (request.UpdateAccessCardModel.ResetHolder)
        {
            accessCard.Value.HolderId = null;
            accessCardRepository.Update(accessCard.Value);
        }

        if (request.UpdateAccessCardModel.HolderId is not null)
        {
            accessCard.Value.HolderId = request.UpdateAccessCardModel.HolderId;
            accessCardRepository.Update(accessCard.Value);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}