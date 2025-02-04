using BillingSystem.Application.Invoice.Commands;
using BillingSystem.Domain.UnitOfWork.Interfaces;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace BillingSystem.Application.Invoice.Handlers.CommandHandlers;

public class DeleteInvoiceCommandHandler (IUnitOfWorkProvider<IUnitOfWork> unitOfWorkProvider)
    : ICommandHandler<DeleteInvoiceCommand, Result>
{
    public async Task<Result> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
    {
        using var unitOfWork = unitOfWorkProvider.Create();
        await unitOfWork.InvoiceRepository.RemoveAsync(request.Id);
        await unitOfWork.Commit();
        return Result.Success();
    }
}
