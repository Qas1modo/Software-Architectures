using BillingSystem.Shared.Models.InvoiceModels;
using MediatR;

namespace BillingSystem.Application.Invoice.Queries;

public record GetAllInvoiceQuery(int Page = -1, int PageSize = -1) : IRequest<List<InvoiceListModel>>;
