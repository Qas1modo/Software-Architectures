using AutoMapper;
using BillingSystem.BL.Commands.InvoiceCommands;
using BillingSystem.BL.Handlers.CommandHandlers.Base;
using BillingSystem.DAL.EFCore.UnitOfWork;
using BillingSystem.DAL.Infrastructure.UnitOfWork.Interfaces;
using MediatR;

namespace BillingSystem.BL.Handlers.CommandHandlers.BillingItemCommandHandlers;

public class DeleteInvoiceCommandHandler : CommandHandler<DeleteInvoiceCommand, bool>, IRequestHandler<DeleteInvoiceCommand, bool>
{
    public DeleteInvoiceCommandHandler(IUnitOfWorkProvider<IEFCoreUnitOfWork> unitOfWorkProvider, IMapper mapper) 
        : base(unitOfWorkProvider, mapper) { }

    public override async Task<bool> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
    {
        using var unitOfWork = _unitOfWorkProvider.Create();
        await unitOfWork.InvoiceRepository.RemoveAsync(request.Id);
        await unitOfWork.Commit();
        return true;
    }
}
