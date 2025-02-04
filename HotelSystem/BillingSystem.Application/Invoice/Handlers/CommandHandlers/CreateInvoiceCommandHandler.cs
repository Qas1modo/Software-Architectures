using BillingSystem.Application.BillingItem.Queries;
using BillingSystem.Application.Invoice.Commands;
using BillingSystem.Domain.Core.Errors;
using BillingSystem.Domain.UnitOfWork.Interfaces;
using MediatR;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace BillingSystem.Application.Invoice.Handlers.CommandHandlers;

public class CreateInvoiceCommandHandler(IUnitOfWorkProvider<IUnitOfWork> unitOfWorkProvider, IMediator mediator)
    : ICommandHandler<CreateInvoiceCommand, Result>
{
    public async Task<Result> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {
        if (request.InvoiceCreateModel.CustomerId == default)
        {
            return Result.Failure(DomainErrors.InvoiceErrors.CustomerIdIsDefault);
        }

        using var unitOfWork = unitOfWorkProvider.Create();
        var invoiceRepository = unitOfWork.InvoiceRepository;

        var query = new GetBillingItemsByCustomerQuery(request.InvoiceCreateModel.CustomerId);
        var customerBillItems = await mediator.Send(query, cancellationToken);

        if (!customerBillItems.HasValue)
        {
            return Result.Failure(DomainErrors.InvoiceErrors.NoItemWasFound);
        }

        var amountOfStay = customerBillItems.Value.Select(x => x.Price).Sum();

        var newInvoice = new Domain.Entities.Invoice.InvoiceEntity(amountOfStay, "CZK", request.InvoiceCreateModel.CustomerId);
        invoiceRepository.Insert(newInvoice);

        await unitOfWork.Commit();

        return Result.Success();
    }
}
