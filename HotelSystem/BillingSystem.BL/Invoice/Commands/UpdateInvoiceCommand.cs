using BillingSystem.Shared.Models.InvoiceModels;
using MediatR;

namespace BillingSystem.Application.Invoice.Commands;

public class UpdateInvoiceCommand(InvoiceUpdateModel InvoiceUpdateModel) : IRequest<InvoiceDetailModel>;
