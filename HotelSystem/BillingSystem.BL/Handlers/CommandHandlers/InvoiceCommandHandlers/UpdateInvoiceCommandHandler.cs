using AutoMapper;
using BillingSystem.BL.Commands.InvoiceCommands;
using BillingSystem.BL.Handlers.CommandHandlers.Base;
using BillingSystem.DAL.EFCore.UnitOfWork;
using BillingSystem.DAL.Infrastructure.UnitOfWork.Interfaces;
using BillingSystem.Shared.Models.InvoiceModels;
using MediatR;

namespace BillingSystem.BL.Handlers.CommandHandlers.BillingItemCommandHandlers;

public class UpdateInvoiceCommandHandler : CommandHandler<UpdateInvoiceCommand, InvoiceDetailModel>, IRequestHandler<UpdateInvoiceCommand, InvoiceDetailModel>
{
    public UpdateInvoiceCommandHandler(IUnitOfWorkProvider<IEFCoreUnitOfWork> unitOfWorkProvider, IMapper mapper) 
        : base(unitOfWorkProvider, mapper) { }

    public override async Task<InvoiceDetailModel> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
    {
        // TODO Add logic
        return null;
    }
}
