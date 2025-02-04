using BillingSystem.Application.BillingItem.Commands;
using BillingSystem.Domain.Core.Errors;
using BillingSystem.Domain.UnitOfWork.Interfaces;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace BillingSystem.Application.BillingItem.Handlers.CommandHandlers;

public class UpdateBillingItemCommandHandler (IUnitOfWorkProvider<IUnitOfWork> unitOfWorkProvider)
    : ICommandHandler<UpdateBillingItemCommand, Result>
{
    public async Task<Result> Handle(UpdateBillingItemCommand request, CancellationToken cancellationToken)
    {
        if (request.BillinItemUpdateModel.BillingItemId == default)
        {
            return Result.Failure(DomainErrors.BillingItemErrors.DefaultBillingItemId);
        }

        using var unitOfWork = unitOfWorkProvider.Create();
        var billingItemRepository = unitOfWork.BillingItemRepository;


        var entity = await billingItemRepository.GetByIdAsync(request.BillinItemUpdateModel.BillingItemId);

        if (entity is null)
        {
            return Result.Failure(DomainErrors.BillingItemErrors.NotFound);
        }

        entity.Update(request.BillinItemUpdateModel);

        await unitOfWork.Commit();

        return Result.Success();
    }
}
