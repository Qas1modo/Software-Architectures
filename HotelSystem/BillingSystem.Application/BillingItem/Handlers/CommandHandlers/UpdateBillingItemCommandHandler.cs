using BillingSystem.Application.BillingItem.Commands;
using BillingSystem.Domain.UnitOfWork.Interfaces;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace BillingSystem.Application.BillingItem.Handlers.CommandHandlers;

public class UpdateBillingItemCommandHandler (IUnitOfWorkProvider<IUnitOfWork> unitOfWorkProvider)
    : ICommandHandler<UpdateBillingItemCommand, Result>
{
    public async Task<Result> Handle(UpdateBillingItemCommand request, CancellationToken cancellationToken)
    {
        // TODO Add logic
        return Result.Success();
    }
}
