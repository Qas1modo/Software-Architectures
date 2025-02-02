using BillingSystem.Application.BillingItem.Commands;
using BillingSystem.Domain.UnitOfWork.Interfaces;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace BillingSystem.Application.BillingItem.Handlers.CommandHandlers;

public class CreateBillingItemCommandHandler (IUnitOfWorkProvider<IUnitOfWork> unitOfWorkProvider)
    : ICommandHandler<CreateBillingItemCommand, Result>
{
    public override async Task<Result> Handle(CreateBillingItemCommand request, CancellationToken cancellationToken)
    {
        // TODO Add logic
        return null;
    }
}
