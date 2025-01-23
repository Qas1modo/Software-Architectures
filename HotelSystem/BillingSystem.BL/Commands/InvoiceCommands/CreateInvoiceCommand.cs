using BillingSystem.Shared.Models.InvoiceModels;
using MediatR;

namespace BillingSystem.BL.Commands.InvoiceCommands;

public record CreateInvoiceCommand(InvoiceCreateModel InvoiceCreateModel) : IRequest<InvoiceDetailModel>;
