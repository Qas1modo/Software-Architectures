using BillingSystem.Application.Invoice.Commands;
using BillingSystem.Domain.Core.Errors;
using BillingSystem.Domain.Events.Invoice;
using BillingSystem.Domain.UnitOfWork.Interfaces;
using MediatR;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace BillingSystem.Application.Invoice.Handlers.CommandHandlers;

public class UpdateInvoiceCommandHandler (IUnitOfWorkProvider<IUnitOfWork> unitOfWorkProvider, IMediator mediator)
    : ICommandHandler<UpdateInvoiceCommand, Result>
{
    public async Task<Result> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
    {
        if (request.InvoiceUpdateModel.InvoiceId == default)
        {
            return Result.Failure(DomainErrors.InvoiceErrors.DefaultInvoiceId);
        }

        using var unitOfWork = unitOfWorkProvider.Create();
        var invoiceRepository = unitOfWork.InvoiceRepository;


        var entity = await invoiceRepository.GetByIdAsync(request.InvoiceUpdateModel.InvoiceId);

        if (entity is null)
        {
            return Result.Failure(DomainErrors.InvoiceErrors.NotFound);
        }

        var wasPaid = entity.IsPaid.Value;

        entity.Update(request.InvoiceUpdateModel);

        await unitOfWork.Commit();

        if (wasPaid != entity.IsPaid.Value && entity.IsPaid.Value)
        {
            var domainEvent = new InvoicePaidDomainEvent(entity);
            await mediator.Send(domainEvent);
        }

        return Result.Success();
    }
}
