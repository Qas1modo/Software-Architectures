using AccessSystem.Domain.Core.Errors;
using AccessSystem.Domain.Repositories;
using SharedKernel.Application.Core.Abstractions.Data;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Application.AccessCard.Commands.DeleteAccessCard;

public class DeleteAccessCardCommandHandler(IAccessCardRepository accessCardRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteAccessCardCommand, Result>
{
    public async Task<Result> Handle(DeleteAccessCardCommand request, CancellationToken cancellationToken)
    {
        var accessCard = await accessCardRepository.GetByIdAsync(request.DeleteAccessCardModel.AccessCardId);

        if (accessCard.HasNoValue)
        {
            return Result.Failure(DomainErrors.AccessCardErrors.NotFound);
        }

        await accessCardRepository.Remove(accessCard);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}