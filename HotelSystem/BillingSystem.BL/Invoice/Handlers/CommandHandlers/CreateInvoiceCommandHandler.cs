using AutoMapper;
using BillingSystem.Application.Handlers.Base;
using BillingSystem.Application.Invoice.Commands;
using BillingSystem.DAL.EFCore.UnitOfWork;
using BillingSystem.DAL.Infrastructure.UnitOfWork.Interfaces;
using BillingSystem.Shared.Models.InvoiceModels;
using MediatR;

namespace BillingSystem.Application.Invoice.Handlers.CommandHandlers;

public class CreateInvoiceCommandHandler : CommandHandler<CreateInvoiceCommand, InvoiceDetailModel>, IRequestHandler<CreateInvoiceCommand, InvoiceDetailModel>
{
    public CreateInvoiceCommandHandler(IUnitOfWorkProvider<IEFCoreUnitOfWork> unitOfWorkProvider, IMapper mapper)
        : base(unitOfWorkProvider, mapper) { }

    public override async Task<InvoiceDetailModel> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {
        // TODO Add logic
        return null;
    }
}
