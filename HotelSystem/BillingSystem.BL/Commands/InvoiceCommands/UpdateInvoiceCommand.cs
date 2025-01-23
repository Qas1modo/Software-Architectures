using BillingSystem.Shared.Models.InvoiceModels;
using MediatR;

namespace BillingSystem.BL.Commands.InvoiceCommands;

public class UpdateInvoiceCommand(InvoiceUpdateModel InvoiceUpdateModel) : IRequest<InvoiceDetailModel>;
