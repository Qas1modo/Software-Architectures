using BillingSystem.Application.BillingItem.Queries;
using BillingSystem.Application.Invoice.Commands;
using BillingSystem.Domain.Core.Errors;
using BillingSystem.Domain.UnitOfWork.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
        var billingItemRepository = unitOfWork.BillingItemRepository;

        var valueOfStay = await billingItemRepository.GetQuery()
            .Where(x => x.CustomerId.Value == request.InvoiceCreateModel.CustomerId)
            .Select(x => x.UnitPrice.Value * x.Quantity.Value)
            .SumAsync();

        var newInvoice = new Domain.Entities.Invoice.InvoiceEntity(valueOfStay, "CZK", request.InvoiceCreateModel.CustomerId);

        var invoiceRepository = unitOfWork.InvoiceRepository;
        invoiceRepository.Insert(newInvoice);

        await unitOfWork.Commit();

        return Result.Success();
    }
}
