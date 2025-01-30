using BillingSystem.Shared.Models.InvoiceModels;
using MediatR;

namespace BillingSystem.Application.Invoice.Queries;

public record GetInvoiceQuery(int InvoiceId) : IRequest<InvoiceDetailModel>;
