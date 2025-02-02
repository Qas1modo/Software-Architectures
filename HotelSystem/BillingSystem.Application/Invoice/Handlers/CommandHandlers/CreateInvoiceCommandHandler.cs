using BillingSystem.Application.Invoice.Commands;
using BillingSystem.Domain.UnitOfWork.Interfaces;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace BillingSystem.Application.Invoice.Handlers.CommandHandlers;

public class CreateInvoiceCommandHandler(IUnitOfWorkProvider<IUnitOfWork> unitOfWorkProvider)
    : ICommandHandler<CreateInvoiceCommand, Result>
{
    public async Task<Result> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {
        // TODO Add logic
        return Result.Success();
    }
}
