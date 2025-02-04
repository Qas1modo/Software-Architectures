using BillingSystem.Application.BillingItem.Commands;
using BillingSystem.Domain.UnitOfWork.Interfaces;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace BillingSystem.Application.BillingItem.Handlers.CommandHandlers;

public class DeleteBillingItemCommandHandler (IUnitOfWorkProvider<IUnitOfWork> unitOfWorkProvider)
    : ICommandHandler<DeleteBillingItemCommand, Result>
{
    public async Task<Result> Handle(DeleteBillingItemCommand request, CancellationToken cancellationToken)
    {
        using var unitOfWork = unitOfWorkProvider.Create();
        await unitOfWork.BillingItemRepository.RemoveAsync(request.Id);
        await unitOfWork.Commit();
        return Result.Success();
    }
}
