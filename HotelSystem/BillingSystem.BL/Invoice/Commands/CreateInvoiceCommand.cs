using BillingSystem.Shared.Models.InvoiceModels;
using MediatR;

namespace BillingSystem.Application.Invoice.Commands;

public record CreateInvoiceCommand(InvoiceCreateModel InvoiceCreateModel) : IRequest<InvoiceDetailModel>;
