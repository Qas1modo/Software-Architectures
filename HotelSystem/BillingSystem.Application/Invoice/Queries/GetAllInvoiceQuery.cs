using BillingSystem.Shared.Models.Invoice;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace BillingSystem.Application.Invoice.Queries;

public record GetAllInvoiceQuery(int Page = -1, int PageSize = -1) : IQuery<Maybe<List<InvoiceListModel>>>;
