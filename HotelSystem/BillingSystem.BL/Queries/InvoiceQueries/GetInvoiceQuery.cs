using BillingSystem.Shared.Models.InvoiceModels;
using MediatR;

namespace BillingSystem.BL.Queries.InvoiceQueries;

public record GetInvoiceQuery(int InvoiceId) : IRequest<InvoiceDetailModel>;
