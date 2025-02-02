using BillingSystem.Application.Invoice.Commands;
using BillingSystem.Domain.UnitOfWork.Interfaces;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace BillingSystem.Application.Invoice.Handlers.CommandHandlers;

public class UpdateInvoiceCommandHandler (IUnitOfWorkProvider<IUnitOfWork> unitOfWorkProvider)
    : ICommandHandler<UpdateInvoiceCommand, Result>
{
    public async Task<Result> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
    {
        // TODO Add logic
        return Result.Success();
    }
}
