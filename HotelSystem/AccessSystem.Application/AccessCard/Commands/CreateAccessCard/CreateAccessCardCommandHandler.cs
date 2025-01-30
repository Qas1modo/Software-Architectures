using AccessSystem.Domain.Entities;
using AccessSystem.Domain.Repositories;
using SharedKernel.Application.Core.Abstractions.Data;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Application.AccessCard.Commands.CreateAccessCard;

public class CreateAccessCardCommandHandler(IAccessCardRepository accessCardRepository, IAccessCardRoleRepository accessCardRoleRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<CreateAccessCardCommand, Result>
{
    public async Task<Result> Handle(CreateAccessCardCommand request, CancellationToken cancellationToken)
    {
        var accessCard = AccessCardEntity.Create();
        if (request.CreateAccessCardModel.HolderId.HasValue)
        {
            accessCard.HolderId = request.CreateAccessCardModel.HolderId.Value;
        }

        accessCardRepository.Insert(accessCard);

        await accessCardRoleRepository.AddRolesToCardByName(accessCard.Id, request.CreateAccessCardModel.RoleNames,
            cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}