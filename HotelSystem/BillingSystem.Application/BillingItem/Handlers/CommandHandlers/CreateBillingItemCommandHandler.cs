using BillingSystem.Application.BillingItem.Commands;
using BillingSystem.Domain.Core.Errors;
using BillingSystem.Domain.UnitOfWork.Interfaces;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace BillingSystem.Application.BillingItem.Handlers.CommandHandlers;

public class CreateBillingItemCommandHandler (IUnitOfWorkProvider<IUnitOfWork> unitOfWorkProvider)
    : ICommandHandler<CreateBillingItemCommand, Result>
{
    public async Task<Result> Handle(CreateBillingItemCommand request, CancellationToken cancellationToken)
    {
        var model = request.BillingItemCreateModel;

        if (model.CustomerId == default)
        {
            return Result.Failure(DomainErrors.BillingItemErrors.CustomerIdIsDefault);
        }

        if (model.ItemId == default)
        {
            return Result.Failure(DomainErrors.BillingItemErrors.ItemIdIsDefault);
        }

        if (model.UnitPrice <= 0)
        {
            return Result.Failure(DomainErrors.BillingItemErrors.NegativeUnitPrice);
        }

        if (model.Quantity <= 0)
        {
            return Result.Failure(DomainErrors.BillingItemErrors.NegativeQuantity);
        }

        using var unitOfWork = unitOfWorkProvider.Create();
        var billingItemRepository = unitOfWork.BillingItemRepository;

        var newBillingItem = new Domain.Entities.BillingItem.BillingItemEntity(model.CustomerId, model.ItemId, model.UnitPrice, model.Quantity);
        billingItemRepository.Insert(newBillingItem);

        await unitOfWork.Commit();

        return Result.Success();
    }
}
